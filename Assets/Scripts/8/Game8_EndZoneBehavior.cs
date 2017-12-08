using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_EndZoneBehavior : MonoBehaviour {

    public bool isPerfect = false;
    public bool noteInZone = false;

    private GameObject gameObjectInZone = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObjectInZone = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObjectInZone = null;
    }

    public void DeleteNote()
    {
        Destroy(gameObjectInZone);
    }
}
