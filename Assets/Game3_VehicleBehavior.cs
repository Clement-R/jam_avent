using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3_VehicleBehavior : MonoBehaviour {
    public Vector2 speed;

    private Rigidbody2D _rb;
    private TrackManager _trackManger;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _trackManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<TrackManager>();
    }
    
	void Update () {
        _rb.velocity = speed;
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print(collider.name);
        _trackManger.Lose();
    }
}
