using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private SpriteRenderer _sr;
    private float groundVerticalLength;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        groundVerticalLength = _sr.sprite.bounds.size.y;
    }

    private void Update()
    {
        if (transform.position.y < -groundVerticalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(0, groundVerticalLength * 2f);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
