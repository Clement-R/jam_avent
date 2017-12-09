using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game9_PlayerController : MonoBehaviour {
    public KeyCode leftMove;
    public KeyCode rightMove;
    public KeyCode attackKey;

    public int life = 100;
    public int damage = 20;

    public float cooldown;
    public float moveSpeed;

    private Rigidbody2D _rb2D;
    private bool _canAttack = true;
    private Game9_PlayerController enemy;
    
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(attackKey) && _canAttack)
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKey(leftMove))
        {
            _rb2D.velocity = new Vector2(-moveSpeed, 0f);
        }
        else if (Input.GetKey(rightMove))
        {
            _rb2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            _rb2D.velocity = new Vector2(0f, 0f);
        }
    }

    private IEnumerator Attack()
    {
        _canAttack = false;
        print("Attack");
        // TODO : Change sprite to attack
        // Check if enemy in trigger box
        transform.GetChild(0).GetComponent<Game9_TriggerBox>().IsEnemyInZone();

        // Damage enemy
        enemy.TakeDamage();

        yield return new WaitForSeconds(cooldown);

        _canAttack = true;
    }

    public void TakeDamage()
    {

    }
}
