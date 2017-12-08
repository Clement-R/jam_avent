using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game8_NoteBehavior : MonoBehaviour {

    public Vector2 End
    {
        set
        {
            this._end = value;
        }
    }

    public bool IsPerfect
    {
        get
        {
            return this._isPerfect;
        }

        set
        {
            this._isPerfect = value;
        }
    }

    public bool IsNormal
    {
        get
        {
            return this._isNormal;
        }

        set
        {
            this._isNormal = value;
        }
    }

    public bool IsMissed
    {
        get
        {
            return this._isMissed;
        }

        set
        {
            this._isMissed = value;
        }
    }

    [SerializeField]
    public float timeToMove;

    public Coroutine coroutine = null;

    private bool _endReached = false;
    private bool _isPerfect = false;
    private bool _isNormal = false;
    private bool _isMissed = false;
    private bool _canMove = true;

    private Vector2 _startPosition;
    private Vector3 _lastPos;
    private Vector2 _end;

    private float _speed = 0.0f;

    void Awake()
    {
        _startPosition = transform.position;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = "game_note";
            sr.sortingOrder = 99;
        }
    }

    private void OnDestroy()
    {
        if (coroutine != null)
        {
            this.StopAllCoroutines();
        }
    }

    void Update()
    {
        if (_endReached && _canMove)
        {
            // Get the direction from the two vectors of start and end
            // Move the note in the direction and in the same velocity that the one created by the MoveToPosition coroutine
            transform.Translate((_end - _startPosition).normalized * Time.deltaTime * _speed);
        }
    }

    public void Launch()
    {
        StartCoroutine(MoveToPosition(_end, timeToMove));
    }

    public void Stop()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = null;
        }
        StopCoroutine("MoveToPosition");
        _canMove = false;
    }

    public IEnumerator MoveToPosition(Vector3 position, float timeToMove)
    {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);

            if (t >= 0.5f && t <= 0.6)
            {
                _speed = (transform.position - _lastPos).magnitude;
            }
            _lastPos = currentPos;

            yield return null;
        }

        _endReached = true;
    }
}
