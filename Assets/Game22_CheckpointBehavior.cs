using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game22_CheckpointBehavior : MonoBehaviour {
    public int index;
    public bool isEnd = false;
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Checkpoint");

            Game22_CarController player = collision.gameObject.GetComponent<Game22_CarController>();
            player.checkpoints[index] = true;

            if(player.checkpoints.All(e => e == true) && isEnd)
            {
                player.AddLap();

                if(player.laps == 3)
                {
                    player.Win();
                }

                // Set all checkpoints to false
                player.checkpoints.ToList().ForEach(e => e = false);
            }
        }
    }
}
