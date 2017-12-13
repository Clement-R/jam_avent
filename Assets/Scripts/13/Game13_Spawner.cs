using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game13_Spawner : MonoBehaviour {

    public Game13_PlayerBehavior player;
    public GameObject piecePrefab;

    public GameObject[] piece;

    public bool canSpawn = true;

    public float spawnTimeMin= 1;
    public float spawnTimeMax = 2;


    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (canSpawn)
        {
            Vector3 spawnPosition = new Vector3(960, 200, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject go = Instantiate(piecePrefab, spawnPosition, spawnRotation);         

            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        }
    }


}
