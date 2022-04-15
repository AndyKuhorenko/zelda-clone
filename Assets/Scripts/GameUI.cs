using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Player player;

    private void Start()
    {
        button.onClick.AddListener(player.HandlePickButtonClick);
    }

    public void ShowButton()
    {
        button.gameObject.SetActive(true);
    }

    public void HideButton()
    {
        button.gameObject.SetActive(false);
    }
}
