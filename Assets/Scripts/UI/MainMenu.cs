using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;


    private void Start()
    {
        newGameButton.onClick.AddListener(OnNewGameClicked);
        continueGameButton.onClick.AddListener(OnContinueGameClicked);

        if (!DataPersistanceManager.Instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        DisableMenuButtons();

        DataPersistanceManager.Instance.NewGame();

        SceneManager.LoadSceneAsync(1);
    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        SceneManager.LoadSceneAsync(1);
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
