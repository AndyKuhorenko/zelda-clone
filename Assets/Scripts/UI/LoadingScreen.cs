using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] GameObject loadingCanvas;
    [SerializeField] TextMeshProUGUI loadingText;

    public static LoadingScreen Instance { get; private set; }

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

    public void ShowLoading(int scene)
    {
        loadingText.text = $"Loading scene {scene}...";
        loadingCanvas.SetActive(true);

        Time.timeScale = 0f;
    }

    public void HideLoading()
    {
        StartCoroutine(HideLoadingCanvas());
    }

    public IEnumerator HideLoadingCanvas()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        loadingCanvas.SetActive(false);

        Time.timeScale = 1f;
    }    
}
