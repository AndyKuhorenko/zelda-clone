using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player : MonoBehaviour
{
    [SerializeField] public Transform destination;
    [SerializeField] public GameUI gameUI;

    private ThirdPersonCharacter character;
    PickUp pickableObject;
    PickUp takenObject;

    private void Start()
    {
        character = GetComponent<ThirdPersonCharacter>();
    }

    private void Update()
    {
        // ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        int layerMask = 1 << 6;

        RaycastHit hit;

        if (Physics.SphereCast(
            new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),
            1f,
            transform.TransformDirection(Vector3.forward),
            out hit,
            0.5f,
            layerMask))
        {
            Debug.Log(true);
            pickableObject = hit.collider.GetComponent<PickUp>();
            gameUI.ShowButton();
        }
        else
        {
            Debug.Log(false);
            if (takenObject == null) gameUI.HideButton();
        }
    }

    public void HandlePickButtonClick()
    {
        if (pickableObject != null)
        {
            if (pickableObject.isPicked)
            {
                pickableObject.Drop();
                takenObject = null;
                character.hasPickedObject = false;
            }
            else
            {
                pickableObject.Pick();
                takenObject = pickableObject;
                character.hasPickedObject = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            pickableObject = other.gameObject.GetComponent<PickUp>();
            gameUI.ShowButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (takenObject == null) gameUI.HideButton();
    }
}
