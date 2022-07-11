using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        int musicPlayersCount = FindObjectsOfType<GameManager>().Length;

        if (musicPlayersCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
