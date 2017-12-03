using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public SockController sockController;

    public bool canSpawn = true;

    public GameObject[] pickUp;
    
    public GameObject WallLeft;
    public GameObject WallRight;

    public int randomSpeed_min;
    public int randomSpeed_max;

    public float startTimeMax = 2f;
    public float startTimeMin = 1f;

    public float endTimeMax = 1f;
    public float endTimeMin = 0.5f;

    private float spawnTimeMax;
    private float spawnTimeMin;

    void Start ()
    {
        StartCoroutine(Spawn());

        spawnTimeMax = startTimeMax;
        spawnTimeMin = startTimeMin;
    }

    IEnumerator Spawn ()
    {
        while (canSpawn)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(WallLeft.transform.position.x +100, WallRight.transform.position.x -100),transform.position.y,0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject go = Instantiate(pickUp[Random.Range(0, pickUp.Length)], spawnPosition, spawnRotation);
            go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(randomSpeed_min, randomSpeed_max);

            if(sockController.GetScore() > 10)
            {
                spawnTimeMax = endTimeMax;
                spawnTimeMin = endTimeMin;
            }

            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        } 
    }
	
}
