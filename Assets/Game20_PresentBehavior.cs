using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game20_PresentBehavior : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public SpriteRenderer present;
    public Sprite[] presents;

    [SerializeField]
    private int _health = 100;
    private Game20_PlayerController _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player").GetComponent<Game20_PlayerController>();
    }
	
	public void Smash()
    {
        _health -= 1;
        StartCoroutine(SquashEffect());

        // TODO : Manage different states of the present
        if (_health >= 70 && _health <= 100)
        {
            present.sprite = presents[0];
        }
        else if (_health >= 40 && _health < 70)
        {
            present.sprite = presents[1];
        }
        else if (_health > 0 && _health < 40)
        {
            present.sprite = presents[2];
        }

        if (_health == 0)
        {
            winPanel.SetActive(true);
            present.sprite = presents[3];
            Time.timeScale = 0f;
        }
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public IEnumerator SquashEffect()
    {
        transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player.IsInPresentRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player.IsInPresentRange = false;
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
