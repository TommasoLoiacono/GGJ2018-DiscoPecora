﻿using UnityEngine;

public class Sheep : MonoBehaviour {

    public float SmoothTime;

    [Range(0f, 1f)]
    public float inertiaDragAmount;

    private bool _underInertia = false;
    private bool dragging = false;
    private float _time = 0f;
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private Vector3 _curScreenPoint;
    private Vector3 _curPosition;
    private Vector3 _velocity;

    void Update () {

        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 30f) * -1;

        Vector3 p = new Vector3();
        Camera c = Camera.main;
        Vector2 mousePos = new Vector2();

        if (dragging)
        {
            // Get the mouse position from Event.
            // Note that the y position from Event is inverted.
            mousePos.x = Input.mousePosition.x;
            mousePos.y = c.pixelHeight - Input.mousePosition.y;

            p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));
            p.y = -p.y;
            p.z = 0;

            transform.position = Vector3.Lerp(transform.position, p, inertiaDragAmount);
            if (Mathf.Abs(transform.position.x) >= 17.5)
                transform.position = new Vector3(17.5f * Mathf.Sign(transform.position.x), transform.position.y, 0);
            if (Mathf.Abs(transform.position.y) >= 10)
                transform.position = new Vector3(transform.position.x, 10 * Mathf.Sign(transform.position.y), 0);

        }
        else
        {
            if (_underInertia && _time <= SmoothTime)
            {
                transform.position += _velocity;
                _velocity = Vector3.Lerp(_velocity, Vector3.down * 0.5f, _time);
                if (transform.position.x >= 17.5)
                {
                    _velocity.x = -Mathf.Abs(_velocity.x);
                }
                if (transform.position.x <= -17.5)
                {
                    _velocity.x = Mathf.Abs(_velocity.x);
                }
                if (transform.position.y >= 10)
                {
                    _velocity.y = -0.3f;
                }
                if (transform.position.y <= -9)
                {
                    Debug.Log("ciao");
                    _velocity.y = 0;
                }
                _time += Time.smoothDeltaTime;
            }
            else
            {
                _underInertia = false;
                _time = 0.0f;

            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameManager.I.UIMng.gameplayCtrl.ShowSheepDatas(GetComponent<Pecora>(), false);
        }
    }

    void OnMouseDown()
    {
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
        _underInertia = false;
        GameManager.I.UIMng.gameplayCtrl.ShowSheepDatas(GetComponent<Pecora>(), true);
    }

    float timer = .2f;

    void OnMouseDrag()
    {
        if (timer <= 0)
        {
            Vector3 _prevPosition = _curPosition;
            _curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
            _curPosition = Camera.main.ScreenToWorldPoint(_curScreenPoint) + _offset;
            _velocity = _curPosition - _prevPosition;
            transform.position = _curPosition;
            dragging = true;
            _underInertia = true;
            return;
        }
        timer -= Time.deltaTime;
    }

    private void OnMouseUp()
    {
        dragging = false;
        timer = .2f;
    }
    
}
