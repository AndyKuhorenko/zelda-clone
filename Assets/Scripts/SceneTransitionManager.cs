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
            Debug.Log("Found more than one TransitionManager in scene! Destroying newest Transition Manager...");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int buildIndex)
    {
        StartCoroutine(Load(buildIndex));
    }

    public IEnumerator Load(int buildIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        MovePlayerToSpawnPoint();
    }

    private void MovePlayerToSpawnPoint()
    {
        SceneEntrance sceneEntrance = FindObjectOfType<SceneEntrance>();
        
        Transform spawnPoint = sceneEntrance.GetSpawnPointTransform();

        FindObjectOfType<Player>().SetPlayerPos(spawnPoint.position);
    }
}
