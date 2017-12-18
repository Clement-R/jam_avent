using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game13_GameManager : MonoBehaviour {

    public GameObject losePanel;
    //public Text endScore;

    public Text score;

    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        print("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
