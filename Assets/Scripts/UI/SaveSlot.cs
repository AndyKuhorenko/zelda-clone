using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;

    [SerializeField] private GameObject dataContent;

    [SerializeField] private TextMeshProUGUI sceneIndex;

    public void SetData(GameData data)
    {
        print(1);
        if (data == null)
        {
            noDataContent.SetActive(true);
            dataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            dataContent.SetActive(true);

            sceneIndex.text = "LEVEL: " + data.currentScene.ToString();
        }
    }

    public string GetProfileId()
    {
        return profileId;
    }
}
