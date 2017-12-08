using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_EndZoneBehavior : MonoBehaviour {

    public bool isPerfect = false;
    public bool noteInZone = false;
    

    private GameObject gameObjectInZone = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        noteInZone = true;
        gameObjectInZone = collision.gameObject.transform.parent.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        noteInZone = false;
        gameObjectInZone = null;
    }

    public void DeleteNote()
    {
        Destroy(gameObjectInZone);
    }
}
