using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game22_CarController : MonoBehaviour {

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;

    public float steering = 150f;
    public float acceleration = 75f;

    public Text lapCounter;
    public GameObject endPanel;
    public Text endText;

    public int laps = 0;
    public bool[] checkpoints = new bool[4];

    private Rigidbody2D _rb;

    void Start ()
    {
        Time.timeScale = 1f;
        _rb = GetComponent<Rigidbody2D>();
        lapCounter.text = laps + " / 3";
    }

    public void AddLap()
    {
        laps++;
        lapCounter.text = laps + " / 3";
    }

    public void Win()
    {
        endText.text = name + " win !";
        endPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void FixedUpdate()
    {
        if(Time.timeScale > 0f)
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

            if (Input.GetKey(upKey))
            {
                _rb.velocity = acceleration * transform.up;
            }
            else if (Input.GetKey(downKey))
            {
                _rb.velocity = acceleration * -transform.up;
            }
        }
    }
}
