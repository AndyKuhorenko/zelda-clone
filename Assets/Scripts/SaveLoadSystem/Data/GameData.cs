using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPos;

    public SerializableDictionary<string, Vector3> movableObjectsPos;


    // Todo refactor initialization
    public GameData()
    {
        playerPos = new Vector3(0, 0, 0);

        movableObjectsPos = new SerializableDictionary<string, Vector3>();
    }
}
