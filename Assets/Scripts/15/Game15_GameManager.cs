using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game15_GameManager : MonoBehaviour {

    public Vector3 smashScale;
    public SpriteRenderer snowSprite;
    public Sprite[] snows;

    public GameObject losePanel;
    public Text endTimer;

    public Text timer;

    private int snowIndex = 0;
    private Vector3 baseScale;
    private int score = 0;

	void Start ()
    {
        baseScale = snowSprite.gameObject.transform.localScale;
        Time.timeScale = 1f;
        snowSprite.sprite = snows[snowIndex];
    }
	
    IEnumerator SmashEffect()
    {
        snowSprite.gameObject.transform.localScale = smashScale;
        yield return new WaitForSeconds(0.05f);
        snowSprite.gameObject.transform.localScale = baseScale;
    }

	void Update ()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AkSoundEngine.PostEvent("Play_Game15_Hit", gameObject);
                StartCoroutine(SmashEffect());
                score++;
                AddScore();
                CheckForEnd();
            }
            
            timer.text = Time.timeSinceLevelLoad.ToString("0.00");
        }
	}

    private void AddScore ()
    {
        if (score % 10 == 0 && score != 0)
        {
            snowIndex++;
            snowSprite.sprite = snows[snowIndex];
        }
    }

    private void CheckForEnd ()
    {
        if (snowIndex == snows.Length -1)
        {
            losePanel.SetActive(true);
            endTimer.text = "Time : " + Time.timeSinceLevelLoad.ToString("0.00");
            Time.timeScale = 0f;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }
}
