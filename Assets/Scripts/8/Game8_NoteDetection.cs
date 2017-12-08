using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_NoteDetection : MonoBehaviour {

    private Game8_EndZoneBehavior endNormal;
    private Game8_EndZoneBehavior endPerfect;

    void Start ()
    {
        endNormal = transform.GetChild(0).GetComponent<Game8_EndZoneBehavior>();
        endPerfect = transform.GetChild(1).GetComponent<Game8_EndZoneBehavior>();
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("R arrow");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("L arrow");
        }
    }
}
