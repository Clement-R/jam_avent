using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6_InputManager : MonoBehaviour {

    public Game6_OrderManager orderManager;
	
	void Update ()
    {
        // Content inputs
        if(orderManager.GetChosenContentSprite() == null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                orderManager.SetChosenContent(orderManager.GetContent(0));
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                orderManager.SetChosenContent(orderManager.GetContent(1));
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                orderManager.SetChosenContent(orderManager.GetContent(2));
            }
        }

        // Topping inputs
        if(orderManager.GetChosenToppingSprite() == null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                orderManager.SetChosenTopping(orderManager.GetTopping(0));
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                orderManager.SetChosenTopping(orderManager.GetTopping(1));
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                orderManager.SetChosenTopping(orderManager.GetTopping(2));
            }
        }
    }
}
