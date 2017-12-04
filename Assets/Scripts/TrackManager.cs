using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackManager : MonoBehaviour {
    
    public Vector2[] tracks;
    public Text scoreText;
    public GameObject losePanel;
    public Text loseScore;
    public GameManager gm;

    private int trackIndex = 1;
    private int _score = 0;

	void Start ()
    {
        Time.timeScale = 1f;
        transform.position = tracks[trackIndex];
        AkSoundEngine.PostEvent("Play_Game4_Music", gameObject);
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(trackIndex + 1 < tracks.Length)
            {
                trackIndex++;
                transform.position = tracks[trackIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (trackIndex - 1 >= 0)
            {
                trackIndex--;
                transform.position = tracks[trackIndex];
            }
        }

        if(losePanel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                gm.Exit();
            }
            else if(Input.anyKeyDown)
            {
                gm.Retry();
            }
        }
    }

    public void Lose()
    {
        AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);
        losePanel.SetActive(true);
        loseScore.text = "Score : " + _score.ToString();
        scoreText.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }
}
