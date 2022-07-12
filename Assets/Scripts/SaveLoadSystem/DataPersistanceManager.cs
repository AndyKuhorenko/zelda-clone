using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;


    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] bool useEncryption;

    private GameData gameData;

    private List<IDataPersistance> dataPersistances;
    private FileDataHandler dataHandler;

    public static DataPersistanceManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one Data Persistance Manager in scene! Destroying newest Manager...");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindAllDataPersistances();
        LoadGame();
        print("SceneLoaded");
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if (gameData == null && initializeDataIfNull)
        {
            NewGame();
        }


        if (gameData == null)
        {
            Debug.Log("No save data was found. Start a new game.");
            return;
        }

        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.LoadData(gameData);
        }

        //Debug.Log("Loaded Player position = " + gameData.playerPos.ToString());
    }
    
    public void SaveGame()
    {
        if (gameData == null)
        {
            Debug.LogWarning("No save data was found. New game should be started.");
            return;
        }

        foreach (IDataPersistance persistance in dataPersistances)
        {
            print(persistance.ToString());
            if (persistance != null) persistance.SaveData(gameData);
        }

        dataHandler.Save(gameData);

        //Debug.Log("Saved Player position = " + gameData.playerPos.ToString());
    }


    private void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            SaveGame();
        }
    }

    private void FindAllDataPersistances()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        dataPersistances = new List<IDataPersistance>(dataPersistanceObjects);
    }

    // Works in Editor mode
    public void RemoveSaves()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        dataHandler.RemoveSaves();
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
