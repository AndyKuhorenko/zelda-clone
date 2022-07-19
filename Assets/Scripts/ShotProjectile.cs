using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProjectile : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    public Vector3 destination;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 dir = speed * transform.forward;

        rb.velocity = dir;
    }
}
