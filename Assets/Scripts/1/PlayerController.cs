using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject losePanel;

    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _hMaxSpeed = 175f;
    [SerializeField]
    private float _vMaxSpeed = 150f;
    [SerializeField]
    private float _shotCooldown = 0.5f;

    private Rigidbody2D _rb;
    private float _nextShot = 0.0f;
    

    void Start () {
        _rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        // Rotation
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        // Shoot !
        if (Input.GetMouseButton(0) && Time.time >= _nextShot) {
            _nextShot = Time.time + _shotCooldown;
            Instantiate(_bullet, transform.GetChild(0).transform.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        // Movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _rb.velocity = Vector2.Scale(new Vector2(h, v), new Vector2(_hMaxSpeed, _vMaxSpeed));
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
