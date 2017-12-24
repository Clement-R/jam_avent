using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game22_CarController : MonoBehaviour {

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;

    public float steering = 150f;
    public float acceleration = 75f;

    private Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.zero;

        if (Input.GetKey(leftKey))
        {
            _rb.rotation += steering;
        }
        else if (Input.GetKey(rightKey))
        {
            _rb.rotation -= steering;
        }

        if(Input.GetKey(upKey))
        {
            _rb.velocity = acceleration * transform.up;
        }
        else if (Input.GetKey(downKey))
        {
            _rb.velocity = acceleration * -transform.up;
        }
    }
}
