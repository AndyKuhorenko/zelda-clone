using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player : MonoBehaviour, IDataPersistance
{
    [SerializeField] public Transform destination;
    [SerializeField] private ThirdPersonCharacter character;
    private GameUI gameUI;

    private Vector3 startPosition;

    Pickable pickableObject;
    Pickable takenObject;

    private void Awake()
    {
        //print("PlayerAwake");
    }

    private void Start()
    {
        gameUI = GameUI.Instance;
        transform.position = startPosition;
    }

    private void Update()
    {
 
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
            pickableObject = other.gameObject.GetComponent<Pickable>();
            gameUI.ShowButton();
        }

        if (other.gameObject.layer == 7)
        {
            SceneEntrance sceneEntrance = other.gameObject.GetComponent<SceneEntrance>();

            sceneEntrance.MoveToScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (takenObject == null) gameUI.HideButton();
    }

    public void LoadData(GameData data)
    {
        //playerPos = data.playerPos;
    }

    public void SaveData(GameData data)
    {
        //data.playerPos = transform.position;
    }

    public void SetPlayerPosition(Vector3 pos)
    {
        startPosition = pos;
        transform.position = startPosition;
    }

    public void SetPlayerRotation(Quaternion rot)
    {
        transform.rotation = rot;
    }
}
