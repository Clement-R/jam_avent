using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game20_PatrolController : MonoBehaviour {

    private Game20_PlayerController player;
    private float _timeBeforeMove = 6f;
    private float _timeToMove = 2f;
    private float[] _rotValues = new float[] { 90f, 25f, -25f, 0f };

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Game20_PlayerController>();
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        float t = 0f;
        float rotation = _rotValues[Random.Range(0, _rotValues.Length)];

        while (rotation == transform.parent.rotation.z)
        {
            rotation = _rotValues[Random.Range(0, _rotValues.Length)];
        }

        while (t < 1)
        {
            t += Time.deltaTime / _timeToMove;
            transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, Quaternion.Euler(0, 0, rotation), t);
            yield return null;
        }

        yield return new WaitForSeconds(_timeBeforeMove);
        StartCoroutine(Patrol());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.IsInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.IsInSight = false;
        }
    }
}
