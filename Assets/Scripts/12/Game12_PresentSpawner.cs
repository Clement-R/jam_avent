using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game12_PresentSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public Sprite[] present;
    public GameObject presentPrefab;

    public float spawnTimeMin;
    public float spawnTimeMax;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (canSpawn)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-850,850), Random.Range(-470,470), 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject go = Instantiate(presentPrefab, spawnPosition, spawnRotation);

            go.GetComponent<SpriteRenderer>().sprite = present[Random.Range(0, present.Length)];
            
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        }
    }
}


