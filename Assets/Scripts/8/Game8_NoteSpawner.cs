using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_NoteSpawner : MonoBehaviour {

    public GameObject notePrefab;
    public float timeToMove;
    public Transform[] spwanersPosition;
    public Transform[] endSpwanersPosition;

    public void LaunchNote(int lane)
    {
        GameObject instantiatedNote = Instantiate(notePrefab, spwanersPosition[lane].position, Quaternion.identity);
        Game8_NoteBehavior noteBehavior = instantiatedNote.GetComponent<Game8_NoteBehavior>();
        noteBehavior.timeToMove = timeToMove;
        noteBehavior.End = endSpwanersPosition[lane].position;
        noteBehavior.Launch();
    }
}
