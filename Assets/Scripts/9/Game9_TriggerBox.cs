using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game9_TriggerBox : MonoBehaviour {
    public string enemyTag;

    private bool _enemyInZone = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == enemyTag)
        {
            _enemyInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            _enemyInZone = false;
        }
    }

    public bool IsEnemyInZone()
    {
        return _enemyInZone;
    }
}
