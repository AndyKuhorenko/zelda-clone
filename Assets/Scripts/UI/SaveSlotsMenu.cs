
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    private SaveSlot[] saveSlots;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        DeactivateMenu();
    }

    public void ActivateMenu()
    {
        gameObject.SetActive(true);

        Dictionary<string, GameData> profilesData = DataPersistanceManager.Instance.GetAllProfilesData();

        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesData.TryGetValue(saveSlot.GetProfileId(), out profileData);

            saveSlot.SetData(profileData);
        }

    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}
