using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public Text text;

    public Game16_GameManager gameManager;

    public float fallSpeed = 80f;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game16_GameManager>();
    }

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.blue;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Time.timeScale == 1f)
        {
            transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
            
            if (GetComponent<RectTransform>().position.y <= -550f)
            {
                gameManager.Lose();
            }
        }        
    }


}
