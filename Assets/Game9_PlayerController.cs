using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game9_PlayerController : MonoBehaviour {
    public KeyCode leftMove;
    public KeyCode rightMove;
    public KeyCode attackKey;

    public Text loseText;

    public GameObject losePanel;

    public Image lifeBar;

    public int life = 100;
    public int damage = 20;

    public float cooldown;
    public float moveSpeed;

    public Game9_PlayerController enemy;

    private Rigidbody2D _rb2D;
    private bool _canAttack = true;
    private Animator _animator;
    
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(attackKey) && _canAttack)
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKey(leftMove) && _canAttack)
        {
            _rb2D.velocity = new Vector2(-moveSpeed, 0f);
            _animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(rightMove) && _canAttack)
        {
            _rb2D.velocity = new Vector2(moveSpeed, 0f);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _rb2D.velocity = new Vector2(0f, 0f);
            _animator.SetBool("isRunning", false);
        }

        if(life <= 0)
        {
            // Activate lose panel
            loseText.text = enemy.name + " wins !";
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }

    private IEnumerator Attack()
    {
        _canAttack = false;
        _animator.SetBool("isAttacking", true);

        // Check if enemy in trigger box
        if(transform.GetChild(0).GetComponent<Game9_TriggerBox>().IsEnemyInZone())
        {
            // Damage enemy
            enemy.TakeDamage();
        }

        yield return new WaitForSeconds(cooldown);

        _animator.SetBool("isAttacking", false);
        _canAttack = true;
    }

    public void TakeDamage()
    {
        life -= damage;

        lifeBar.fillAmount = life / 100f;
    }
}
