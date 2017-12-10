using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game14_LevelGenerator : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject endPlatform;

    public int numberOfPlatforms;
    public float levelWidth;
    public float minY;
    public float maxY;

	void Start ()
    {
        Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        spawnPosition.x = 0f;
        spawnPosition.y += Random.Range(minY, maxY);
        Instantiate(endPlatform, spawnPosition, Quaternion.identity);
    }
}
