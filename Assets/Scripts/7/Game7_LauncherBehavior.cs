using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7_LauncherBehavior : MonoBehaviour {

    public GameObject bullet;

    public float velocity;
    public float angle;
    public LineRenderer line;

    public bool playerOne;

    private float _maxVelocity = 30000;
    private float _minVelocity = 15000;
    private float _maxDistance = 600;
    private float _minDistance = 100;

    private GameObject _actualBullet = null;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get angle between tank and mouse position
        Vector2 targetDir = mousePosition - new Vector2(transform.position.x, transform.position.y);

        var dir = mousePosition - new Vector2(transform.position.x, transform.position.y);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        
        // Get distance between tank and mouse position to set the velocity
        float distance = Vector2.Distance(transform.position, mousePosition);

        if(distance >= _maxDistance)
        {
            line.SetPosition(1, new Vector3(0, 100, 0));
            velocity = _maxVelocity;
        }
        else if(distance <= _minDistance)
        {
            line.SetPosition(1, new Vector3(0, 10, 0));
            velocity = _minVelocity;
        }
        else
        {
            float delta = distance / 5f;
            if(delta >= 100)
            {
                delta = 100;
            }

            line.SetPosition(1, new Vector3(0, delta, 0));

            // Compute velocity based on the distance
            velocity = ((distance - _minDistance) / (_maxDistance - _minDistance)) * ((_maxVelocity - _minVelocity));
            velocity += _minVelocity;
        }
        
        if (Input.GetMouseButtonDown(0) && _actualBullet == null && Time.timeScale > 0f)
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile ()
    {
        float radianAngle;

        if (playerOne)
        {
            radianAngle = Mathf.Deg2Rad * angle;
        }
        else
        {
            radianAngle = Mathf.Deg2Rad * angle;
        }
        
        Vector2 initialVelocity = new Vector2(velocity * Mathf.Cos(radianAngle), velocity * Mathf.Sin(radianAngle));

        _actualBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb2d = _actualBullet.GetComponent<Rigidbody2D>();

        rb2d.AddForce(initialVelocity);
	}
}
