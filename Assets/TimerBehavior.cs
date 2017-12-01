using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour {

    public Text timerText;
    private float _timer = 24f;
    
	private void Update()
    {
        _timer -= Time.deltaTime;

        timerText.text = _timer.ToString("0.000");

        if (_timer <= 0f)
        {
            Debug.Log("You win !");
        }
    }
}
