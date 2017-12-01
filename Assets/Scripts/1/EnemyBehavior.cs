using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField]
    private float _speed = 120f;
    private GameObject _player;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player");
    }

	void Update ()
    {
        transform.right = _player.transform.position - transform.position;
        _rb.velocity = (_player.transform.position - transform.position).normalized * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);
            collision.gameObject.GetComponent<PlayerController>().Lose();
        }
    }
}
