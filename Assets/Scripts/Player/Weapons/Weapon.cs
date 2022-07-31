using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int ammo;
    [SerializeField] protected float timeBetweenShots = 0.25f;
    [SerializeField] protected GameObject debugCube;
    [SerializeField] protected GameObject shotProjectile;
    [SerializeField] protected ThirdPersonUserControl thirdPersonUserControl;

    protected InputManager inputManager;
    protected Camera mainCamera;

    protected bool canShoot = true;
    protected int layerMask = 1 << 8;

    private void Start()
    {
        mainCamera = Camera.main;
        inputManager = InputManager.Instance;

        layerMask = ~layerMask;
    }

    private void Update()
    {
        if (inputManager.ShotWasPressed() && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    public virtual IEnumerator Shoot()
    {
        yield return null;
    }
}
