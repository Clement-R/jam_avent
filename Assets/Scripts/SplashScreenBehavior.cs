using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenBehavior : MonoBehaviour {

    [SerializeField]
    private GameObject _kzlkzl;
    [SerializeField]
    private GameObject _scarounet;
    [SerializeField]
    private ParticleSystem _particleSystem;
    [SerializeField]
    private Text _names;
    [SerializeField]
    private AnimationCurve _namesCurve;
    [SerializeField]
    private Image _endPanel;

    private float _lastKzlkzlPosition = 0f;

    private bool _hasAnimationFinished = false;

    void Start ()
    {
        StartCoroutine(LoadStartScene());
	}
	
	void Update ()
    {
        print(_kzlkzl.transform.position.x);
		if(_kzlkzl.transform.position.x == _lastKzlkzlPosition && _particleSystem != null)
        {
            print("In position");
            if(!_particleSystem.isPlaying)
            {
                AkSoundEngine.PostEvent("Play_Game1_win", gameObject);
                _particleSystem.Play();
                StartCoroutine(ShowNames());
            }
        }

        _lastKzlkzlPosition = _kzlkzl.transform.position.x;
    }

    IEnumerator ShowNames()
    {
        float t = 0f;
        while(t <= 0.5f)
        {
            _names.color = new Color(_names.color.r, _names.color.g, _names.color.b, Mathf.Lerp(0, 1, t * 2));
            t += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(ShowEnd());
    }

    IEnumerator ShowEnd() {
        yield return new WaitForSeconds(2f);
        float t = 0f;
        while (t <= 0.5f) {
            _endPanel.color = new Color(_endPanel.color.r, _endPanel.color.g, _endPanel.color.b, Mathf.Lerp(0, 1, t * 2));
            t += Time.deltaTime;
            yield return null;
        }

        _hasAnimationFinished = true;
    }

    IEnumerator LoadStartScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("8");
        asyncLoad.allowSceneActivation = false;

        while (!_hasAnimationFinished) {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
