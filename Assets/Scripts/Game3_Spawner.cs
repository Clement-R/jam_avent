using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3_Spawner : MonoBehaviour {

    [System.Serializable]
    public class Wave
    {
        public Vector3 type;
    }

    public GameObject vehiclePrefab;
    public List<Wave> waveTypes;
    public Vector2[] tracks;
    public Sprite[] vehicleSprites;
    public float delayBeforeNextWave = 1f;
    
    void Start ()
    {
        StartCoroutine(Spawn());
	}
	
	IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delayBeforeNextWave);
        SpawnVehicles();

        StartCoroutine(Spawn());
    }

    private void SetRandomSprite(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().sprite = vehicleSprites[Random.Range(0, vehicleSprites.Length)];
    }

    void SpawnVehicles()
    {
        // Get random wave type
        Wave wave = waveTypes[Random.Range(0, waveTypes.Count)];

        // Spawn random vehicles at the wave locations
        if(wave.type.x == 1)
        {
            GameObject go = Instantiate(vehiclePrefab, tracks[0], Quaternion.identity);
            SetRandomSprite(go);
        }
        if (wave.type.y == 1)
        {
            GameObject go = Instantiate(vehiclePrefab, tracks[1], Quaternion.identity);
            SetRandomSprite(go);
        }
        if (wave.type.z == 1)
        {
            GameObject go = Instantiate(vehiclePrefab, tracks[2], Quaternion.identity);
            SetRandomSprite(go);
        }
    }
}
