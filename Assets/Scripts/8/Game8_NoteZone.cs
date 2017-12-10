using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_NoteZone : MonoBehaviour {

    public bool isInZone = false;
    public bool isPerfect = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isPerfect)
        {
            if (collision.name == "Perfect")
            {
                isInZone = true;
            }
        }
        else
        {
            if (collision.name == "Normal")
            {
                isInZone = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPerfect)
        {
            if (collision.name == "Perfect")
            {
                isInZone = true;
            }
        }
        else
        {
            if (collision.name == "Normal")
            {
                isInZone = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isPerfect)
        {
            if (collision.name == "Perfect")
            {
                isInZone = false;
            }
        }
        else
        {
            if (collision.name == "Normal")
            {
                isInZone = false;
            }
        }
    }
}
