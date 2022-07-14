using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    [SerializeField] private bool isDataPersistanceDisabled = false;


    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] bool useEncryption;

    private bool isNewGameStart = false;

    private GameData gameData;

    private List<IDataPersistance> dataPersistances;
    private FileDataHandler dataHandler;
    private GameManager gameManager;

    private string selectedProfileId = "";

    public static DataPersistanceManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            //Debug.Log("Destroying newest Manager...");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        if (isDataPersistanceDisabled) Debug.LogWarning("Data persistance is disabled!");

        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        selectedProfileId = dataHandler.GetMostRecentlyUpdatedProfileId();
        //print(selectedProfileId);
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
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
        //bool isPlayerChangesScene = gameManager.GetIsPlayerChangesScene();
        if (isNewGameStart)
        {
            isNewGameStart = false;
            return;
        }

        FindAllDataPersistances();
        LoadGame();

        //if (isPlayerChangesScene)
        //{
        //    gameManager.SetIsPlayerChangesScene(false);
        //}
        //else
        //{
        //}
    }

    public void OnSceneUnloaded(Scene scene)
    {
        //bool isPlayerChangesScene = gameManager.GetIsPlayerChangesScene();
        //print("SceneUnLoaded");

        if (SceneManager.GetActiveScene().buildIndex != 0) SaveGame();
        //if (isPlayerChangesScene)
        //{

        //}
        //else
        //{
        //}
    }

    public void NewGame()
    {
        print("new game");
        gameData = new GameData();
        gameManager.SetGameData(gameData);

        isNewGameStart = true;
    }

    public void LoadGame()
    {
        if (isDataPersistanceDisabled) return;

        gameData = dataHandler.Load(selectedProfileId);

        // Debug
        //if (gameData == null && initializeDataIfNull)
        //{
        //    NewGame();
        //}

        if (gameData == null)
        {
            Debug.Log("No save data was found at profile " + selectedProfileId + " Start a new game.");
            return;
        }

        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.LoadData(gameData);
        }

        gameManager = GameManager.Instance;
        gameManager.SetGameData(gameData);
        Debug.Log("Loaded profile: " + selectedProfileId);
        //Debug.Log("Loaded Player position = " + gameData.playerPos.ToString());
    }
    
    public void SaveGame()
    {
        if (isDataPersistanceDisabled) return;

        if (gameData == null)
        {
            Debug.LogWarning("No save data was found.");
            return;
        }

        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.SaveData(gameData);
        }

        gameManager.SaveGameData(gameData);

        gameData.lastUpdated = DateTime.Now.ToBinary();

        dataHandler.Save(gameData, selectedProfileId);

        Debug.Log("Game Saved...");
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

    #region Debug
    // Works in Editor mode
    public void RemoveSaves()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        var profiles = dataHandler.LoadAllProfiles();

        foreach (var profile in profiles)
        {
            dataHandler.RemoveSaves(profile.Key);
        }

        dataHandler = null;
    }

    public void RemoveSaveByProfileId(string profileId)
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        dataHandler.RemoveSaves(profileId);

        dataHandler = null;
    }

    public Dictionary<string, GameData> GetAllProfilesDataInEditor()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        var profiles = dataHandler.LoadAllProfiles();

        dataHandler = null;

        return profiles;
    }
    #endregion // Debug

    public bool HasGameData()
    {
        gameData = dataHandler.Load(selectedProfileId);
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesData()
    {
        return dataHandler.LoadAllProfiles();
    }

    public void ChangeSelectedProfileId(string newProfileId)
    {
        selectedProfileId = newProfileId;
        LoadGame();
    }
}
