using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;

    [SerializeField] private GameObject dataContent;

    [SerializeField] private TextMeshProUGUI sceneIndex;

    private Button slotButton;

    public bool HasData { get; private set; } = false;

    private void Awake()
    {
        slotButton = GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        if (data == null)
        {
            noDataContent.SetActive(true);
            dataContent.SetActive(false);

            HasData = false;
        }
        else
        {
            noDataContent.SetActive(false);
            dataContent.SetActive(true);

            HasData = true;

            sceneIndex.text = "LEVEL: " + data.currentScene.ToString();
        }
    }

    public string GetProfileId()
    {
        return profileId;
    }

    public void SetInteractable(bool interactable)
    {
        slotButton.interactable = interactable;
    }
}
