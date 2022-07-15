
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    [Header("Confirmation popup")]
    [SerializeField] ConfirmationPopup confirmationPopup;

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

        if (isLoadingGame)
        {
            DataPersistanceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            GameManager.Instance.SetState(GameState.Active);
        }
        else if (saveSlot.HasData)
        {
            confirmationPopup.ActivateMenu(
                "Starting a new game with this slot will override the currently saved data. Are you sure?",
                // Will executed if player select 'YES'
                () =>
                {
                    DataPersistanceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    DataPersistanceManager.Instance.NewGame();
                    GameManager.Instance.SetState(GameState.Active);
                },
                // Will executed if player select 'NO'
                () =>
                {
                    // Return to menu
                    ActivateMenu(false);

                    EnableMenuButtons();
                }
            );
        }
        else
        {
            DataPersistanceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            DataPersistanceManager.Instance.NewGame();
            GameManager.Instance.SetState(GameState.Active);
        }
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }

        backButton.interactable = false;
    }

    private void EnableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(true);
        }

        backButton.interactable = true;
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

        SetFirstSelected(firstSelected.GetComponent<Button>());
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}
