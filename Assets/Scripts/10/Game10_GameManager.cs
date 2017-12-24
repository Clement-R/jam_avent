using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game10_GameManager : MonoBehaviour {
    public float timeToLive = 60f;

    public GameObject startPanel;
    public GameObject losePanelEarlyShoo;
    public GameObject losePanelUncleSpoke;
    public GameObject winPanel;

    public GameObject playerFinger;

    public SpriteRenderer eyes;
    public SpriteRenderer mouth;
    public SpriteRenderer wine;
    public SpriteRenderer red;

    public Sprite[] wineLevels;
    public Sprite[] mouthSprites;
    public Sprite[] eyesSprites;
    public Sprite[] redSprites;

    public Sprite eyesShoo;
    public Sprite mouthShoo;

    public Text timer;

    private bool _canShoo = false;
    private float _nextMouth = 0f;
    private float _nextWine = 2f;
    private float _shooWindow = 2f;
    private float _shooEnd = 0f;
    private int _wineIndex = 0;

    void Start ()
    {
        mouth.sprite = mouthSprites[Random.Range(0, mouthSprites.Length)];
        startPanel.SetActive(true);
        Time.timeScale = 0f;
        playerFinger.SetActive(false);
        wine.sprite = wineLevels[0];
    }

    IEnumerator Shoo()
    {
        AkSoundEngine.PostEvent("Play_Game10_Shh", gameObject);
        playerFinger.SetActive(true);
        eyes.sprite = eyesShoo;
        mouth.sprite = mouthShoo;

        if (!_canShoo)
        {
            LoseByEarlyShoo();
        }

        _canShoo = false;

        yield return new WaitForSeconds(0.5f);

        playerFinger.SetActive(false);

        // Reset wine variables
        _wineIndex = 0;
        _nextWine = Time.time + 1.5f;

        // Reset sprites
        wine.sprite = wineLevels[_wineIndex];
        red.sprite = redSprites[_wineIndex];
        eyes.sprite = eyesSprites[_wineIndex];

        // Re-launch mouth sprite changing
        mouth.sprite = mouthSprites[Random.Range(0, mouthSprites.Length)];
        _nextMouth = Time.time + Random.Range(0.15f, 0.55f);
    }
	
	void Update ()
    {
        if(timeToLive <= 0f)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Time.timeScale > 0f)
        {
            timeToLive -= Time.deltaTime;
            timer.text = "Timer : " + timeToLive.ToString("0.00");

            // Shoo the uncle
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > 1f)
            {
                StartCoroutine(Shoo());
            }
            
            // Choose random mouth when uncle speak
            if(Time.time >= _nextMouth && !playerFinger.activeSelf)
            {
                mouth.sprite = mouthSprites[Random.Range(0, mouthSprites.Length)];
                _nextMouth = Time.time + Random.Range(0.15f, 0.55f);
            }
            
            // Drop wine level time by time
            if (Time.time >= _nextWine)
            {
                _wineIndex++;
                
                if (_wineIndex == wineLevels.Length)
                {
                    _wineIndex = 0;
                }

                // If we're on last wine level
                if(_wineIndex == wineLevels.Length - 1)
                {
                    wine.sprite = wineLevels[_wineIndex];
                    _canShoo = true;
                    _shooEnd = Time.time + _shooWindow;
                    _nextWine = Time.time + 100f;
                }
                else
                {
                    wine.sprite = wineLevels[_wineIndex];
                    _nextWine = Time.time + 1.5f;
                }

                // Change red level and eyes when wine level drop
                red.sprite = redSprites[_wineIndex];
                eyes.sprite = eyesSprites[_wineIndex];
            }

            // Lose by racist uncle
            if (Time.time >= _shooEnd && _canShoo)
            {
                LoseByUncleSpoke();
                Time.timeScale = 0f;
            }
        }

        if (startPanel.activeSelf)
        {
            // At the beginning of the game show a start menu
            if (Input.anyKeyDown)
            {
                startPanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    private void LoseByEarlyShoo()
    {
        Lose();
        losePanelEarlyShoo.SetActive(true);
    }

    private void LoseByUncleSpoke()
    {
        Lose();
        losePanelUncleSpoke.SetActive(true);
    }

    private void Lose()
    {
        Time.timeScale = 0f;
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
