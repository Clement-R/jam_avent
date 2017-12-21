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
        _numberOfElf += _ratePerMs * Time.deltaTime * 1000;
        numberOfElves.text = _numberOfElf.ToString("0");
        yield return null;
        StartCoroutine(Up());
    }

    public void Click()
    {
        _numberOfElf += _elfPerClick;
    }

    public void AddRate(int rate, int price)
    {
        if(_numberOfElf - price >= 0)
        {
            _ratePerSecond += rate;
            ComputeRatePerMs();
            _numberOfElf -= price;
        }
    }

    public void AddClickValue(int value, int price)
    {
        if (_numberOfElf - price >= 0)
        {
            _elfPerClick += value;
            _numberOfElf -= price;
        }
    }
}
