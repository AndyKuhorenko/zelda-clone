using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private int buildIndex;

    private SceneTransitionManager sceneTransition;

    private void Start()
    {
        sceneTransition = SceneTransitionManager.Instance;
    }

    public Transform GetSpawnPointTransform()
    {
        return spawnPoint.transform;
    }

    public void MoveToScene()
    {
        sceneTransition.LoadScene(buildIndex);
    }
}
