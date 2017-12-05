using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private void Awake()
    {
        Time.timeScale = 1f;
        DontDestroyOnLoad(gameObject);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        // SceneManager.LoadScene("main_menu");
        Application.Quit();
    }
}
