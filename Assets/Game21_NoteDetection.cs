using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game21_NoteDetection : MonoBehaviour
{

    public KeyCode key;
    public Game21_GameManager gameManager;
    public SpriteRenderer leftSanta;
    public SpriteRenderer rightSanta;
    public Sprite idleL;
    public Sprite kissL;
    public Sprite idleR;
    public Sprite kissR;
    public ParticleSystem ps;

    private Game21_EndZoneBehavior endNormal;
    private Game21_EndZoneBehavior endPerfect;

    void Start()
    {
        endNormal = transform.GetChild(1).GetComponent<Game21_EndZoneBehavior>();
        endPerfect = transform.GetChild(0).GetComponent<Game21_EndZoneBehavior>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (endPerfect.noteInZone)
            {
                //leftTree.sprite 

                if (key.ToString().Contains("Right"))
                {
                    StartCoroutine(Kiss(rightSanta));
                }
                else if (key.ToString().Contains("Left"))
                {
                    StartCoroutine(Kiss(leftSanta));
                }

                gameManager.AddScore();
                endPerfect.DeleteNote();
                print(key.ToString() + " Perfect note detected");
                ps.Play();
            }

            if (endNormal.noteInZone)
            {
                if (key.ToString().Contains("Right"))
                {
                    StartCoroutine(Kiss(rightSanta));
                }
                else if (key.ToString().Contains("Left"))
                {
                    StartCoroutine(Kiss(leftSanta));
                }

                gameManager.AddScore();
                endNormal.DeleteNote();
                print(key.ToString() + " Normal note detected");
                ps.Play();
            }
        }
    }

    IEnumerator Kiss(SpriteRenderer sr)
    {
        if(sr == leftSanta)
        {
            sr.sprite = kissL;
            yield return new WaitForSeconds(0.2f);
            sr.sprite = idleL;
        }
        else
        {
            sr.sprite = kissR;
            yield return new WaitForSeconds(0.2f);
            sr.sprite = idleR;
        }
    }
}
