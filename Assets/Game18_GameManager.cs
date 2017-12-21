using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game18_GameManager : MonoBehaviour {

    public Text numberOfElves;

    [SerializeField]
    private int _ratePerSecond = 10;
    [SerializeField]
    private float _elfPerClick = 1;
    private float _ratePerMs = 0;
    private float _numberOfElf = 0;

    void Start ()
    {
        ComputeRatePerMs();
        StartCoroutine(Up());
    }

    void ComputeRatePerMs()
    {
        _ratePerMs = _ratePerSecond / 1000f;
        print(_ratePerMs);
    }

    IEnumerator Up()
    {
        _numberOfElf += (int)Mathf.Ceil(_ratePerMs * Time.deltaTime);
        numberOfElves.text = _numberOfElf.ToString();
        yield return null;
        StartCoroutine(Up());
    }

    public void Click()
    {
        _numberOfElf += _elfPerClick;
    }
}
