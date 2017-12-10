using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game14_GameManager : MonoBehaviour {

    public float gravityForce;

	void Start ()
    {
        Physics2D.gravity = new Vector2(0, gravityForce);
    }
}
