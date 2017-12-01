using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour {

    public Text timerText;
    public GameObject winPanel;

    private static float _timer = 24f;
    
	private void Update()
    {
        _timer -= Time.deltaTime;

        timerText.text = _timer.ToString("0.000");

        if (_timer <= 0f)
        {
            timerText.text = ("0.000");
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            timerText.text = _timer.ToString("0.000");
        }
    }

    public static float GetTimer()
    {
        return _timer;
    }
}
