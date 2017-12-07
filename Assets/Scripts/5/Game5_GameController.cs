using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game5_GameController : MonoBehaviour {

    public GameObject[] presents;
    public Sprite[] presentSprites;
    public Image nextPresent;

    public Text score;
    public Text finalScore;
    
    private float _dropCooldown = 0.5f;
    private float _timeBeforeDrop = 0f;
    private GameObject _nextPresent;
    private int _score = 0;
    private Sprite _sprite;

    private void Start()
    {
        _nextPresent = presents[Random.Range(0, presents.Length)];
        _sprite = presentSprites[Random.Range(0, presentSprites.Length)];
        nextPresent.sprite = _sprite;
    }

    void Update ()
    {
		if(Input.GetMouseButtonDown(0) && Time.time >= _timeBeforeDrop)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(pos.x >= -525f && pos.x <= 525f && pos.y >= -319 && pos.y <= 350)
            {
                AkSoundEngine.PostEvent("Play_Game5_Click", gameObject);

                GameObject go = Instantiate(_nextPresent, pos, Quaternion.identity);
                go.GetComponent<SpriteRenderer>().sprite = _sprite;
                
                _nextPresent = presents[Random.Range(0, presents.Length)];
                _sprite = presentSprites[Random.Range(0, presentSprites.Length)];

                _score++;

                switch (_nextPresent.name)
                {
                    case "small":
                        nextPresent.rectTransform.sizeDelta = new Vector2(50, 50);
                        break;

                    case "medium":
                        nextPresent.rectTransform.sizeDelta = new Vector2(75, 75);
                        break;

                    case "large":
                        nextPresent.rectTransform.sizeDelta = new Vector2(100, 100);
                        break;
                }

                nextPresent.sprite = _sprite;

                score.text = _score.ToString();
                finalScore.text = _score.ToString();

                _timeBeforeDrop = Time.time + _dropCooldown;
            }
        }
	}
}
