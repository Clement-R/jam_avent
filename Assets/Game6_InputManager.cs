using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6_InputManager : MonoBehaviour {

    public Game6_OrderManager orderManager;
	
	void Update ()
    {
        if(Time.timeScale > 0)
        {
            // Content inputs
            if (orderManager.GetChosenContentSprite() == null)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
                    orderManager.SetChosenContent(orderManager.GetContent(0));
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
                    orderManager.SetChosenContent(orderManager.GetContent(1));
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
                    orderManager.SetChosenContent(orderManager.GetContent(2));
                }
            }

            // Topping inputs
            if (orderManager.GetChosenToppingSprite() == null)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
                    orderManager.SetChosenTopping(orderManager.GetTopping(0));
                }

                if (Input.GetKeyDown(KeyCode.K))
                {
                    AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
                    orderManager.SetChosenTopping(orderManager.GetTopping(1));
                }

                if (Input.GetKeyDown(KeyCode.L))
                {
                    AkSoundEngine.PostEvent("Play_Game1_Hit", gameObject);
                    orderManager.SetChosenTopping(orderManager.GetTopping(2));
                }
            }
        }
    }
}
