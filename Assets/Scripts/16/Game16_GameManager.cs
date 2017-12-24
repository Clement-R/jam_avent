using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game16_GameManager : MonoBehaviour {

    public Text timer;
    public GameObject losePanel;
    public Text loseScore;

    private int _score = 0;

    private void Start()
    {
        Time.timeScale = 1f;        
    }

    private void Update()
    {
        timer.text = Time.timeSinceLevelLoad.ToString("0.0");
    }

    public void Lose()
    {
        AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);
        losePanel.SetActive(true);
        loseScore.text = "Time : " + Time.timeSinceLevelLoad.ToString("0.00");
        timer.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        print("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }
}
