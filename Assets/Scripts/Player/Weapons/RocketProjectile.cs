using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject fireVFX;
    public Vector3 destination;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        var particles = fireVFX.GetComponent<ParticleSystemMultiplier>();

        particles.multiplier = Random.Range(1, 3);

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

        Explode();
    }

    public void Explode()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StopAllCoroutines();

            GameObject fire = Instantiate(fireVFX, transform.position, Quaternion.identity);
            Destroy(fire, 10f);

            Explode();
        }
    }
}
