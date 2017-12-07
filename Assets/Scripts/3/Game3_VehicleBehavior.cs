using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3_VehicleBehavior : MonoBehaviour {
    public Vector2 speed;

    private Rigidbody2D _rb;
    public TrackManager _trackManager;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _trackManager = GameObject.FindGameObjectWithTag("Player").GetComponent<TrackManager>();

        speed.y -= Time.time * 10;

        if(speed.y <= -800)
        {
            speed.y = -800;
        }
    }
    
	void Update () {
        _rb.velocity = speed;
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            _trackManager.Lose();
        }
        else
        {
            _trackManager.AddScore();
            Destroy(gameObject, 1f);
        }
    }
}
