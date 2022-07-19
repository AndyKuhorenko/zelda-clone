using System;
using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject shotProjectile;
    [SerializeField] private float timeBetweenShots = 0.25f;
    [SerializeField] private int ammo = 10;
    [SerializeField] private ThirdPersonUserControl thirdPersonUserControl;
    private bool canShoot = true;

    private float touchZCoord;

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

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (ammo > 0)
        {
            // TODO refactor shot position
            // Shot position should be at weapon position
            // Weapon should look forward to enemy
            Vector3 playerPosition = thirdPersonUserControl.gameObject.transform.position;

            thirdPersonUserControl.SetCanMove(false);

            Vector3 direction = (GetTouchWorldPos(inputManager.GetTouchPosition()) - playerPosition).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            thirdPersonUserControl.gameObject.transform.rotation = lookRotation;

            playerPosition = thirdPersonUserControl.gameObject.transform.position;

            Vector3 shotStartPos = new Vector3(playerPosition.x, playerPosition.y + 1, playerPosition.z);

            GameObject shot = Instantiate(shotProjectile, shotStartPos, lookRotation);

            Destroy(shot, 2f);

            //ammo--;

            //print(GetMouseWorldPos(inputManager.GetTouchPosition()));
            // Shoot
            thirdPersonUserControl.SetCanMove(true);
        }
        else
        {
            // Todo show notification about 0 ammo
        }

        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
    }

    private Vector3 GetTouchWorldPos(Vector2 controllerScreenPos)
    {
        touchZCoord = mainCamera.WorldToScreenPoint(thirdPersonUserControl.gameObject.transform.position).z;

        Vector3 touchPoint = controllerScreenPos;

        touchPoint.z = touchZCoord;

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPoint);

        print(worldPos);

        return new Vector3(
            worldPos.x,
            worldPos.y,
            worldPos.z
        );
    }

}
