using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6_GameManager : MonoBehaviour {

    public SpriteRenderer contentSprite;
    public SpriteRenderer toppingSprite;

    public Game6_OrderManager orderManager;

    void Start ()
    {
        contentSprite = null;
        toppingSprite = null;
    }
	
    private void Update()
    {
        this.contentSprite.sprite = orderManager.GetChosenContent().sprite;
        this.toppingSprite.sprite = orderManager.GetChosenTopping().sprite;
    }
}
