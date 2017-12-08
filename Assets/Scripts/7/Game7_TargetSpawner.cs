using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game7_TargetSpawner : MonoBehaviour {

    public GameObject target;

    public float minX;
    public float maxX;

    private GameObject _actualTarget;

    private void Start()
    {
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        Vector2 pos = new Vector2(Random.Range(minX, maxX), transform.position.y);
        _actualTarget = Instantiate(target, pos, Quaternion.identity);
    }
	
	void Update () {
		if(_actualTarget == null)
        {
            SpawnTarget();
        }
	}
}
