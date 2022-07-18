using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static GameState currentState = GameState.Start;
    [SerializeField] private static GameState previousState = GameState.Start;

    private bool isPlayerChangesScene = false;
    private int currentScene = 1;

    private SceneTransitionManager sceneTransitionManager;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
       // print("awwake");

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //print("start");
        //CheckState();
        sceneTransitionManager = SceneTransitionManager.Instance;
    }

    public void SetState(GameState state)
    {
        previousState = currentState;

        currentState = state;

        CheckState();
    }

    public void SetStateWithoutCheck(GameState state)
    {
        previousState = currentState;

        currentState = state;
    }

    public GameState GetState()
    {
        return currentState;
    }

    public GameState GetPreviousState()
    {
        return previousState;
    }


    public void SetIsPlayerChangesScene(bool isChanges)
    {
        isPlayerChangesScene = isChanges;
    }

    public bool GetIsPlayerChangesScene()
    {
        return isPlayerChangesScene;
    }

    public void SetGameData(GameData data)
    {
        currentScene = data.currentScene;
        //print(sceneToLoad);
    }

    public void SaveGameData(GameData data)
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        data.currentScene = buildIndex;
    }

    public void ContinueGame()
    {
        SceneManager.LoadSceneAsync(currentScene);
    }

    public void SetCurrentScene(int sceneIndex)
    {
        currentScene = sceneIndex;
    }

    private void SetActiveState()
    {
        LoadScene();
    }

    public void SetStartState()
    {
        SceneManager.LoadSceneAsync(0); // Main menu
    }

    public void LoadScene()
    {
        sceneTransitionManager.LoadScene(currentScene);
    }

    private void CheckState()
    {
        switch (currentState)
        {
            case GameState.Start:
                SetStartState();
                break;

            case GameState.Pause:
                break;

            case GameState.Active:
                SetActiveState();
                break;

            default:
                return;
        }
    }
}
