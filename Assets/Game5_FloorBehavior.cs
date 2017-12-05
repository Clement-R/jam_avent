using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5_FloorBehavior : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "PickUp")
        {
            print("Lose");
        }
    }
}
