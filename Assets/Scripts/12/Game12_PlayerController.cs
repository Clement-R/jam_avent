using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game12_PlayerController : MonoBehaviour {

    public KeyCode leftMove;
    public KeyCode rightMove;
    public KeyCode upMove;
    public KeyCode downMove;

    public float moveSpeed;

    public Game12_GameManager gameManager;

    private Rigidbody2D _rb2D;


    void Start ()
    {            
        _rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Time.timeScale > 0)
        {            
            if (Input.GetKey(leftMove))
            {
                _rb2D.velocity = new Vector2(-moveSpeed, 0f);
            }
            else if (Input.GetKey(rightMove))
            {
                _rb2D.velocity = new Vector2(moveSpeed, 0f);
            }
            else if (Input.GetKey(upMove))
            {
                _rb2D.velocity = new Vector2(0f, moveSpeed);
            }
            else if (Input.GetKey(downMove))
            {
                _rb2D.velocity = new Vector2(0f, -moveSpeed);
            }
            else
            {
                _rb2D.velocity = new Vector2(0f, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Present"))
        {
            AkSoundEngine.PostEvent("Play_Game11_Click", gameObject);

            Destroy(other.gameObject);
            gameManager.AddScore(this.name);
        }
        
    }
}
