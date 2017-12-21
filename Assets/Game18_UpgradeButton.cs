using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game18_UpgradeButton : MonoBehaviour {

    public int price;
    public int rateUpgrade = 0;
    public int clickUpgrade = 0;

    private Game18_GameManager _gameManager;

    void Start ()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game18_GameManager>();
    }

    void OnMouseDown()
    {
        if(rateUpgrade > 0)
        {
            _gameManager.AddRate(rateUpgrade, price);
        }
        
        if(clickUpgrade > 0)
        {
            _gameManager.AddClickValue(clickUpgrade, price);
        }
    }
}
