using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnRateStart = 1.5f;
    public float spawnRateEnd = 0.1f;
    
    public GameObject enemyPrefab;

    private float _timer = 0f;
    private float _spawnRate;

    private void Start()
    {
        _spawnRate = spawnRateStart;
    }
    
	void Update () {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            SpawnEnemy();
            _timer = _spawnRate;
        }

        float rate = Mathf.Abs(1 - (TimerBehavior.GetTimer() / 24f));
        _spawnRate = Mathf.Lerp(spawnRateStart, spawnRateEnd, rate);
    }

    void SpawnEnemy()
    {
        // Get random position, depends of the side of the spawner
        Vector2 position;
        if (transform.position.x == 0)
        {
            position = new Vector2(transform.position.x + (RandomSign() * Random.Range(0, 230)), transform.position.y);
        }
        else
        {
            position = new Vector2(transform.position.x, transform.position.y + (RandomSign() * Random.Range(0, 230)));
        }
        
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    int RandomSign()
    {
        return Random.value< .5? 1 : -1;
    }
}
