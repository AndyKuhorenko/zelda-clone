using System;
using System.Collections;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public override IEnumerator Shoot()
    {
        canShoot = false;

        if (ammo > 0)
        {
            // TODO refactor shot position
            // Shot position should be at weapon position
            // Weapon should look forward to enemy
            Vector3 playerPosition = thirdPersonUserControl.transform.position;

            thirdPersonUserControl.SetCanMove(false);

            Vector3 worldPos;

            Ray ray = mainCamera.ScreenPointToRay(inputManager.GetTouchPosition());
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData, 100))
            {
                worldPos = hitData.point;
                Vector3 direction = (worldPos - playerPosition).normalized;

                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

                thirdPersonUserControl.transform.rotation = lookRotation;

                playerPosition = thirdPersonUserControl.transform.position;

                Vector3 shotStartPos = new Vector3(playerPosition.x, playerPosition.y + 1, playerPosition.z);

                GameObject shot = Instantiate(shotProjectile, shotStartPos, lookRotation); // Self - destroyed

                //ammo--;
            }

            thirdPersonUserControl.SetCanMove(true);
        }
        else
        {
            // Todo show notification about 0 ammo
            print($"You have {ammo} ammo...");
        }

        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
    }
}
