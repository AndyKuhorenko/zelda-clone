using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] GameObject hitEffect;
    private int range = 15;

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
                // Create muzzle flash

                worldPos = hitData.point;
                Vector3 direction = (worldPos - playerPosition).normalized;

                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

                thirdPersonUserControl.transform.rotation = lookRotation;

                playerPosition = thirdPersonUserControl.transform.position;

                Vector3 shotStartPos = new Vector3(playerPosition.x, playerPosition.y + 1, playerPosition.z);

                ProcessRaycast(shotStartPos);
                ammo--;
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

    private void ProcessRaycast(Vector3 shotStartPos)
    {
        RaycastHit hit;
        if (Physics.Raycast(shotStartPos, thirdPersonUserControl.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            //EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            //if (target)
            //{
            //    target.TakeDamage(damage);
            //}
            //else
            //{
            //    return;
            //}
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        //
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
