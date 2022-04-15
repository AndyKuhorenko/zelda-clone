using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] public Transform destination;
    public bool isPicked = false;
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
}
