using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7_LauncherBehavior : MonoBehaviour {

    public GameObject bullet;

    public float velocity;
    public float angle;
    public LineRenderer line;

    private float _maxVelocity = 30000;
    private float _minVelocity = 15000;
    private float _maxDistance = 600;
    private float _minDistance = 100;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get angle between tank and mouse position
        Vector2 targetDir = mousePosition - new Vector2(transform.position.x, transform.position.y);
        angle = Vector2.Angle(targetDir, transform.right);

        line.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // Get distance between tank and mouse position to set the velocity
        float distance = Vector2.Distance(transform.position, mousePosition);
        // print(distance);

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
            print(delta);

            line.SetPosition(1, new Vector3(0, delta, 0));

            // Compute velocity based on the distance
            velocity = ((distance - _minDistance) / (_maxDistance - _minDistance)) * ((_maxVelocity - _minVelocity));
            velocity += _minVelocity;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile ()
    {
        float radianAngle = Mathf.Deg2Rad * angle;

        Mathf.Cos(radianAngle);
        Mathf.Sin(radianAngle);

        Vector2 initialVelocity = new Vector2(velocity * Mathf.Cos(radianAngle), velocity * Mathf.Sin(radianAngle));

        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb2d = go.GetComponent<Rigidbody2D>();

        rb2d.AddForce(initialVelocity);
	}
}
