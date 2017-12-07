using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5_FloorBehavior : MonoBehaviour {

    public GameObject losePanel;
    
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "PickUp")
        {
            AkSoundEngine.PostEvent("Play_Game1_lose", gameObject);
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
