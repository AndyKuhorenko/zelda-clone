using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    private Player player;
    public static SceneTransitionManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            //Debug.Log("Found more than one TransitionManager in scene! Destroying newest Transition Manager...");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        MovePlayerToSpawnPoint();
    }

    private void Start()
    {
        
    }

    public void LoadScene(int buildIndex)
    {
        GameManager.Instance.SetIsPlayerChangesScene(true);

        if (SceneManager.GetActiveScene().buildIndex != 0) DataPersistanceManager.Instance.SaveGame();

        StartCoroutine(Load(buildIndex));
    }

    public IEnumerator Load(int buildIndex)
    {
        LoadingScreen.Instance.ShowLoading(buildIndex);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        MovePlayerToSpawnPoint();

        LoadingScreen.Instance.HideLoading();
    }

    // Works after player enter scene & when scene is loaded from save
    private void MovePlayerToSpawnPoint()
    {
        // Todo improve
        SceneEntrance sceneEntrance = FindObjectOfType<SceneEntrance>();

        if (sceneEntrance != null)
        {
            Vector3 playerPosition = sceneEntrance.GetSpawnPointPosition();
            Quaternion playerRotation = sceneEntrance.GetRotationAfterSpawn();

            Player player = FindObjectOfType<Player>();
            player.SetPlayerPosition(playerPosition);
            player.SetPlayerRotation(playerRotation);
        }
    }
}
