using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] GameObject loadingCanvas;

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

    public void ShowLoading()
    {
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
