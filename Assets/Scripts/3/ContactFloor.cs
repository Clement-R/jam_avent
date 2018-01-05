using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContactFloor : MonoBehaviour {
    public SpawnController sp;

    public GameObject[] hearts;
    public GameObject LoseText;
    public GameObject b_Retry;
    public GameObject b_Exit;

    private int lives;
    
	void Start ()
    {
        lives = 3;
        Time.timeScale = 1f;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);

            Destroy(other.gameObject);
            lives--;
            Lose();
            if (hearts[0] == null)
            {
                Destroy(hearts[1]);
            }
            else
            {
                Destroy(hearts[0]);
            }
            if (hearts[1] == null)
            {
                Destroy(hearts[2]);
            }
        }
    }

    void Lose ()
    {
		if (lives == 0)
        {
            Time.timeScale = 0f;
            sp.canSpawn = false;
            b_Retry.SetActive(true);
            b_Exit.SetActive(true);
            LoseText.SetActive(true);
        }        
	}

    public void Retry ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }
}
