using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistance> dataPersistances;
    private FileDataHandler dataHandler;

    public static DataPersistanceManager Instance { get; private set; }


    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        FindAllDataPersistances();
        LoadGame();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in scene!");
        }

        Instance = this;
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if (gameData == null)
        {
            Debug.Log("No save data was found. Initializing new game.");
            NewGame();
        }

        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.LoadData(gameData);
        }

        //Debug.Log("Loaded Player position = " + gameData.playerPos.ToString());
    }
    
    public void SaveGame()
    {
        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.SaveData(gameData);
        }

        dataHandler.Save(gameData);

        //Debug.Log("Saved Player position = " + gameData.playerPos.ToString());
    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void FindAllDataPersistances()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        dataPersistances = new List<IDataPersistance>(dataPersistanceObjects);
    }

    public void RemoveSaves()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        dataHandler.RemoveSaves();
    }
}
