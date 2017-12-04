using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4_StartMenuManager : MonoBehaviour {

    public static Game4_StartMenuManager instance;

    void Start()
    {
        if(instance == null)
        {
            Time.timeScale = 0f;
            instance = this;
        }
        else
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}
