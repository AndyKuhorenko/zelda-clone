using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pickable object should not be placed at Vector3.zero
// Todo fix position check in LoadData
public class Pickable : MonoBehaviour, IDataPersistance
{
    [SerializeField] public Transform destination;
    [SerializeField] private string id;

    public bool isPicked = false;

    private void Start()
    {

    }

    public void Pick()
    {
        isPicked = true;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = destination.position;
        transform.parent = GameObject.Find("Destination").transform;
    }

    public void Drop()
    {
        isPicked = false;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
    }

    public void GenerateID()
    {
        if (id == "")
        {
            id = System.Guid.NewGuid().ToString();
            print("New ID generated!");
        }
    }

    public void LoadData(GameData data)
    {
        var movables = data.movableObjectsPos;

        if (movables != null)
        {
            Vector3 position;

            movables.TryGetValue(id, out position);

            if (position != Vector3.zero) transform.position = position;
        }
    }

    public void SaveData(GameData data)
    {
        var movables = data.movableObjectsPos;

        if (movables.ContainsKey(id))
        {   
            movables.Remove(id);
        }

        movables.Add(id, transform.position);
    }
}
