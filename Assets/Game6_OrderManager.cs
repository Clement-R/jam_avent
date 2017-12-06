using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6_OrderManager : MonoBehaviour {

    [System.Serializable]
    public class Order
    {
        public Order(Ingredient content, Ingredient topping)
        {
            this.content = content;
            this.topping = topping;
        }

        public Ingredient content;
        public Ingredient topping;
    }

    [System.Serializable]
    public class Ingredient
    {
        public KeyCode key;
        public Sprite sprite;
    }

    public float timeToMakeOrders = 50f;

    [SerializeField]
    private Ingredient[] _contents;
    [SerializeField]
    private Ingredient[] _toppings;
    
    private Order _actualOrder;
    private float _gameEndTimer;

    private Ingredient _chosenContent;
    private Ingredient _chosenTopping;

    private int _score = 0;

    void Start ()
    {
        _gameEndTimer = Time.time + timeToMakeOrders;
    }
	
	void Update ()
    {
        if(Time.time >= _gameEndTimer)
        {
            // TODO : End of the game
        }

        // TODO : If the player press the SEND input, check the chosen Content and Topping
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Hello");
            if (_actualOrder.content == _chosenContent && _actualOrder.topping == _chosenTopping)
            {
                // TODO : Add score and update text
                _score++;
            }
            else
            {
                // TODO : Lose score and update text
                _score--;
            }

            // Send next order
            NewOrder();

            // TODO : Clear screen from previous sprites
            // Clear previous order variables
            _chosenContent = null;
            _chosenTopping = null;
        }
    }

    private void NewOrder()
    {
        // Create new order : one random topping and one random content
        Ingredient content = _contents[Random.Range(0, _contents.Length)];
        Ingredient topping = _toppings[Random.Range(0, _toppings.Length)];
        _actualOrder = new Order(content, topping);
    }

    public void SetChosenContent(Ingredient content)
    {
        _chosenContent = content;
    }

    public void SetChosenTopping(Ingredient topping)
    {
        _chosenTopping = topping;
    }

    public Ingredient GetChosenContent()
    {
        return _chosenContent;
    }

    public Ingredient GetChosenTopping()
    {
        return _chosenTopping;
    }
}
