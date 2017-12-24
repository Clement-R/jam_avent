using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    
    private void Start()
    {
        StartCoroutine(StartMusic());
    }

    IEnumerator StartMusic()
    {
        AkSoundEngine.PostEvent("MainMenu", gameObject);
        yield return new WaitForSeconds(1f);
        AkSoundEngine.PostEvent("Play_Game2_Music", gameObject);
    }

    public void LoadScene(string sceneName)
    {
        AkSoundEngine.PostEvent("Play_Game1_win", gameObject);
        SceneManager.LoadScene(sceneName);
    }
}
