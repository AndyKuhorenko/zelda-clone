using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Button pickUpButton;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
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
