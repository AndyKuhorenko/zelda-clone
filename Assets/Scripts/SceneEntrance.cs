using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private int buildIndex;
    [SerializeField] private Quaternion rotationAfterSpawn;

    private SceneTransitionManager sceneTransition;

    private void Start()
    {
        sceneTransition = SceneTransitionManager.Instance;
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
        sceneTransition.LoadScene(buildIndex);
    }
}
