﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game20_PlayerController : MonoBehaviour {

    public bool IsInSight = false;
    public bool IsInPresentRange = false;

    [SerializeField]
    private float _hMaxSpeed = 175f;
    [SerializeField]
    private float _vMaxSpeed = 150f;

    private Game20_PresentBehavior _present;
    private Rigidbody2D _rb;

    void Start () {
        Time.timeScale = 1f;
        _rb = GetComponent<Rigidbody2D>();
        _present = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Game20_PresentBehavior>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsInPresentRange && Time.timeScale > 0f)
        {
            if(IsInSight)
            {
                _present.Lose();
                Time.timeScale = 0f;
            }
            else
            {
                print("MASH");
                _present.Smash();
            }
        }
    }

    private void FixedUpdate()
    {
        if(Time.timeScale > 0f)
        {
            // Movement
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            _rb.velocity = Vector2.Scale(new Vector2(h, v), new Vector2(_hMaxSpeed, _vMaxSpeed));
        }
    }
}
