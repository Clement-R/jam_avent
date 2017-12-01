using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnRate = 1f;
    public GameObject enemyPrefab;

    private float _timer = 0f;

	void Start () {
		
	}
	
	void Update () {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            SpawnEnemy();
            _timer = Time.time + spawnRate;
        }
	}

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
