using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player : MonoBehaviour, IDataPersistance
{
    [SerializeField] public Transform destination;
    [SerializeField] public GameUI gameUI;

    public ThirdPersonCharacter character;
    private Vector3 playerPos;

    Pickable pickableObject;
    Pickable takenObject;

    private void Awake()
    {
        print("PlayerAwake");
    }

    private void Start()
    {
        print("PlayerStart");
        character = GetComponent<ThirdPersonCharacter>();
        transform.position = playerPos;
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
        playerPos = data.playerPos;
    }

    public void SaveData(GameData data)
    {
        data.playerPos = transform.position;
    }

    public void SetPlayerPos(Vector3 pos)
    {
        playerPos = pos;
    }
}
