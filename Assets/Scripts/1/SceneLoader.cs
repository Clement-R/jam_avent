using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public GameObject credits;
    
    public void LoadScene(string sceneName)
    {
        AkSoundEngine.PostEvent("Play_Game1_win", gameObject);
        SceneManager.LoadScene(sceneName);
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            credits.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
