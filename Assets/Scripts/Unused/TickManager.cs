using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour {

    [SerializeField]
    private int _ratePerSecond = 10;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        int ratePerMs = _ratePerSecond / (int) (Time.fixedDeltaTime * 1000);
        // print(Time.fixedDeltaTime * 1000);
        print(ratePerMs);
    }
}
