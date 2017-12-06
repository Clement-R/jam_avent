using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6_InputManager : MonoBehaviour {

    public Game6_OrderManager orderManager;

    void Start () {
		
	}
	
	void Update () {

        // TODO : Get actual order
        // TODO : Check if content is ok
        // TODO : If content is nok, check if one content key is pressed
        // TODO : If content is ok, check if one topping key is pressed

        // Content inputs
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

        }

        if (Input.GetKeyDown(KeyCode.D))
        {

        }

        // Topping inputs
        if (Input.GetKeyDown(KeyCode.J))
        {

        }

        if (Input.GetKeyDown(KeyCode.K))
        {

        }

        if (Input.GetKeyDown(KeyCode.L))
        {

        }
    }
}
