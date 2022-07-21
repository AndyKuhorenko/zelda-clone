using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : MonoBehaviour
{
    [SerializeField] private int speed = 2;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject hitVFX;
    public Vector3 destination;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Countdown());
    }

    void FixedUpdate()
    {
        Vector3 dir = speed * transform.forward;

        rb.velocity = dir;
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1.5f);

        DestroyShot();
    }

    public void DestroyShot()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StopAllCoroutines();

            GameObject hit = Instantiate(hitVFX, transform.position, Quaternion.identity);
            Destroy(hit, 0.1f);

            DestroyShot();
        }
    }
}
