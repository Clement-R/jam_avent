using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game20_PresentBehavior : MonoBehaviour {

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
        // TODO : Manage different states of the present

        if(_health == 0)
        {
            // TODO : end game
            print("Win");
        }
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
}
