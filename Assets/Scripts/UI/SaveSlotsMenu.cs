
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    private SaveSlot[] saveSlots;

    [SerializeField] private Button backButton;

    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        DataPersistanceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());

        if (!isLoadingGame)
        {
            DataPersistanceManager.Instance.NewGame();
        }

        GameManager.Instance.SetState(GameState.Active);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }

        backButton.interactable = false;
    }

    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        DeactivateMenu();
    }

    public void ActivateMenu(bool isLoading)
    {
        gameObject.SetActive(true);

        isLoadingGame = isLoading;

        // Load all profiles
        Dictionary<string, GameData> profilesData = DataPersistanceManager.Instance.GetAllProfilesData();

        GameObject firstSelected = backButton.gameObject;

        // Set profiles data in save slots
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData;
            profilesData.TryGetValue(saveSlot.GetProfileId(), out profileData);

            saveSlot.SetData(profileData);

            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);

                if (firstSelected.Equals(backButton.gameObject))
                {
                    firstSelected = saveSlot.gameObject;
                }
            }
        }

        StartCoroutine(SetFirstSelected(firstSelected));
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}
