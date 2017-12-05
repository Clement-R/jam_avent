using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5_GameController : MonoBehaviour {

    public GameObject[] presents;
    public Sprite[] presentSprites;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            print("Hello world");
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject go = Instantiate(presents[Random.Range(0, presents.Length)], pos, Quaternion.identity);
        }
	}
}
