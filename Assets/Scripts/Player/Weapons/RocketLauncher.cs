using System;
using System.Collections;
using UnityEngine;

public class RocketLauncher : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject shotProjectile;
    [SerializeField] private float timeBetweenShots = 0.25f;
    [SerializeField] private int ammo = 10;
    [SerializeField] private ThirdPersonUserControl thirdPersonUserControl;
    [SerializeField] private GameObject debugCube;
    private bool canShoot = true;

    private InputManager inputManager;

    private Camera mainCamera;

    void Start()
    {
        inputManager = InputManager.Instance;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (inputManager.ShotWasPressed() && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Shoot()
    {
        canShoot = false;

        if (ammo > 0)
        {
            // TODO refactor shot position
            // Shot position should be at weapon position
            // Weapon should look forward to enemy
            Vector3 playerPosition = thirdPersonUserControl.gameObject.transform.position;

            thirdPersonUserControl.SetCanMove(false);

            Vector3 worldPos;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData, 100))
            {
                worldPos = hitData.point;
                Vector3 direction = (worldPos - playerPosition).normalized;

                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

                thirdPersonUserControl.gameObject.transform.rotation = lookRotation;

                playerPosition = thirdPersonUserControl.gameObject.transform.position;

                Vector3 shotStartPos = new Vector3(playerPosition.x, playerPosition.y + 1, playerPosition.z);

                GameObject shot = Instantiate(shotProjectile, shotStartPos, lookRotation); // Self - destroyed
                //ammo--;
            }

            thirdPersonUserControl.SetCanMove(true);
        }
        else
        {
            // Todo show notification about 0 ammo
        }

        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
    }
}
