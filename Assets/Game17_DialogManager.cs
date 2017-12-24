using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game17_DialogManager : MonoBehaviour {

    public string[] messages;
    public SpriteRenderer mouthSr;
    public Sprite[] mouth;
    public float clickCooldown = 1f;
    public Text message;

    public GameObject button1;
    public GameObject button2;
    public GameObject endButton;

    private int _messageIndex = 0;
    private float _nextMessage = 0f;
	
	void Start ()
    {
        message.text = messages[_messageIndex];
        StartCoroutine(ChangeMouth());
    }

    IEnumerator ChangeMouth()
    {
        mouthSr.sprite = mouth[Random.Range(0, mouth.Length)];
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(ChangeMouth());
    }

    public void NextMessage()
    {
        if(Time.time >= _nextMessage)
        {
            if (_messageIndex + 1 == messages.Length - 1)
            {
                StartCoroutine(EndGame());
            }
            else
            {
                // Display new message
                _messageIndex++;
                message.text = messages[_messageIndex];
                _nextMessage = Time.time + clickCooldown;
            }
        }
    }

    IEnumerator EndGame()
    {
        // Show last message
        _messageIndex++;
        message.text = messages[_messageIndex];
        // Hide buttons
        button1.SetActive(false);
        button2.SetActive(false);
        yield return new WaitForSeconds(clickCooldown);
        // TODO : Game end panel
        endButton.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }
}
