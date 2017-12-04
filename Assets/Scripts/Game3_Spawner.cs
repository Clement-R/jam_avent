using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3_Spawner : MonoBehaviour {

    [System.Serializable]
    public class Wave
    {
        public Vector3 type;
    }

    public List<Wave> waveTypes;
    public Vector2[] tracks;
    public float delayBeforeNextWave = 1f;
    
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void SpawnVehicles()
    {
        Wave wave = waveTypes[Random.Range(0, waveTypes.Count)];
        if(wave.type.x == 1)
        {
            
        }
        if (wave.type.y == 1)
        {

        }
        if (wave.type.z == 1)
        {

        }
    }
}
