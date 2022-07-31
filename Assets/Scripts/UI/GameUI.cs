using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Button pickUpButton;
    [SerializeField] private Player player;

    public static GameUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        pickUpButton.onClick.AddListener(player.HandlePickButtonClick);
    }

    public void ShowButton()
    {
        pickUpButton.gameObject.SetActive(true);
    }

    public void HideButton()
    {
        pickUpButton.gameObject.SetActive(false);
    }
}
