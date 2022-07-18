using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private int buildIndex;
    [SerializeField] private Quaternion rotationAfterSpawn;

    private SceneTransitionManager sceneTransition;
    private GameManager gameManager;

    private void Start()
    {
        sceneTransition = SceneTransitionManager.Instance;
        gameManager = GameManager.Instance;
    }

    public Vector3 GetSpawnPointPosition()
    {
        return spawnPoint.transform.position;
    }

    public Quaternion GetRotationAfterSpawn()
    {
        return rotationAfterSpawn;
    }

    public void MoveToScene()
    {
        gameManager.SetCurrentScene(buildIndex);
        gameManager.LoadScene();
    }
}
