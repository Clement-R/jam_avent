using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game21_GameManager : MonoBehaviour
{

    public Text scoreText;
    public Text finalScoreText;
    public Text percent;
    public Game21_Sequencer sequencer;
    public GameObject losePanel;

    private int _successPercent = 0;
    private int _score = 0;
    private int _numNotes = 0;
    private int _numNotesPlayed = 0;

    void Update()
    {
        if (_numNotes == 0)
        {
            _numNotes = sequencer.GetNumberOfNotes();
        }

        scoreText.text = _score.ToString();
        finalScoreText.text = "Score : " + _score.ToString();
        percent.text = _numNotesPlayed.ToString() + " / " + _numNotes.ToString();

        if (sequencer.IsFinished())
        {
            losePanel.SetActive(true);
        }
    }

    public void AddScore()
    {
        _numNotesPlayed++;
        _score += 10;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
