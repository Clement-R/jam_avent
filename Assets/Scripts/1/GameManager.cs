using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private void Awake()
    {
        AkSoundEngine.PostEvent("Play_Game1_Music", gameObject);
        Time.timeScale = 1f;
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
