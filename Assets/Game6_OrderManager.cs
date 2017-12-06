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
        public string name;
    }

    [SerializeField]
    private Ingredient[] _contents;
    [SerializeField]
    private Ingredient[] _toppings;
    
    private Order _actualOrder;
    private float _gameEndTimer;

    private Ingredient _chosenContent = null;
    private Ingredient _chosenTopping = null;

    private int _score = 0;

    private void Start()
    {
        // Send first order
        NewOrder();
    }

    void Update ()
    {
        // If the player press the SEND input, check the chosen Content and Topping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_actualOrder.content == _chosenContent && _actualOrder.topping == _chosenTopping)
            {
                _score++;
            }
            else
            {
                _score--;
            }

            // Send next order
            NewOrder();
            
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

    public Sprite GetChosenContentSprite()
    {
        if(_chosenContent != null)
        {
            return _chosenContent.sprite;
        }

        return null;
    }

    public Sprite GetChosenToppingSprite()
    {
        if(_chosenTopping != null)
        {
            return _chosenTopping.sprite;
        }
        
        return null;
    }

    public int GetScore()
    {
        return this._score;
    }

    public Ingredient GetContent(int id)
    {
        return _contents[id];
    }

    public Ingredient GetTopping(int id)
    {
        return _toppings[id];
    }

    public Order GetActualOrder()
    {
        return _actualOrder;
    }
}
