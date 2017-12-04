using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour {
    
    public Vector2[] tracks;

    private int trackIndex = 1;

	void Start ()
    {
        Time.timeScale = 1f;
        transform.position = tracks[trackIndex];	
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(trackIndex + 1 < tracks.Length)
            {
                trackIndex++;
                transform.position = tracks[trackIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (trackIndex - 1 >= 0)
            {
                trackIndex--;
                transform.position = tracks[trackIndex];
            }
        }
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        print("Lose");
    }
}
