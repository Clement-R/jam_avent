using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_NoteDetection : MonoBehaviour {

    public KeyCode key;
    public Game8_GameManager gameManager;
    public SpriteRenderer leftTree;
    public SpriteRenderer rightTree;
    public Sprite leftMove;
    public Sprite rightMove;

    private Game8_EndZoneBehavior endNormal;
    private Game8_EndZoneBehavior endPerfect;

    void Start ()
    {
        endNormal = transform.GetChild(1).GetComponent<Game8_EndZoneBehavior>();
        endPerfect = transform.GetChild(0).GetComponent<Game8_EndZoneBehavior>();
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(key))
        {
            if(endPerfect.noteInZone)
            {
                //leftTree.sprite 

                if(key.ToString().Contains("Right"))
                {
                    leftTree.sprite = rightMove;
                    rightTree.sprite = rightMove;
                }
                else if(key.ToString().Contains("Left"))
                {
                    leftTree.sprite = leftMove;
                    rightTree.sprite = leftMove;
                }

                gameManager.AddScore();
                endPerfect.DeleteNote();
                print(key.ToString() + " Perfect note detected");
            }

            if (endNormal.noteInZone)
            {
                if (key.ToString().Contains("Right"))
                {
                    leftTree.sprite = rightMove;
                    rightTree.sprite = rightMove;
                }
                else if (key.ToString().Contains("Left"))
                {
                    leftTree.sprite = leftMove;
                    rightTree.sprite = leftMove;
                }

                gameManager.AddScore();
                endNormal.DeleteNote();
                print(key.ToString() + " Normal note detected");
            }
        }
    }
}
