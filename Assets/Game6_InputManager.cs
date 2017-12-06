using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6_InputManager : MonoBehaviour {

    public Game6_OrderManager orderManager;

    void Start () {
		
	}
	
	void Update () {

        // TODO : Get actual order
        // TODO : Check if one content key is pressed : if GetChoseContent() == null then set, else ignore
        // TODO : Same for topping

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
