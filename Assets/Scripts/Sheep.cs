﻿using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Sheep : MonoBehaviour {

    public float SmoothTime;

    [Range(0f, 1f)]
    public float inertiaDragAmount;
    public float speed = 1;
    public int timeBetweenMovments = 4;

    public DiscoPecoraGame DiscoPecora;
    //  public DiscoPecoraGame
    public bool _underInertia = false;
    public bool dragging = false;
    private float _time = 0f;
    private Vector3 startPosition;
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private Vector3 _curScreenPoint;
    private Vector3 _curPosition;
    private Vector3 _velocity;
    private float startTime;
    public bool CR_running;

    private void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
        StartCoroutine("DanzingAround", Random.Range(1, 3));
    }

    void Update () {

        //GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 30f) * -1;

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
            if (Mathf.Abs(transform.position.x) >= 8.75f)
                transform.position = new Vector3(8.75f * Mathf.Sign(transform.position.x), transform.position.y, 0);
            if (transform.position.y >= 4f)
                transform.position = new Vector3(transform.position.x, 4, 0);
            if (transform.position.y <= -6f)
                transform.position = new Vector3(transform.position.x, -6f, 0);
        }
        else
        {
            if (_underInertia && _time <= SmoothTime)
            {
                transform.position += _velocity;
                _velocity = Vector3.Lerp(_velocity, Vector3.down * 0.5f, _time);
                if (transform.position.x >= 8f)
                {
                    _velocity.x = -Mathf.Abs(_velocity.x);
                }
                if (transform.position.x <= -8f)
                {
                    _velocity.x = Mathf.Abs(_velocity.x);
                }
                if (transform.position.y >= 4f)
                {
                    _velocity.y = -0.3f;
                }
                if (transform.position.y <= -6f)
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

    IEnumerator DanzingAround()
    {
        while (true)
        {
            int _seconds = Random.Range(0, 3);
            if(!CR_running)
            {
                StartCoroutine("MoveAround", _seconds);
            }
            yield return new WaitForSeconds(_seconds+Random.Range(1,timeBetweenMovments));
        }

        
    }

    IEnumerator MoveAround(int _seconds)
    {
        
        CR_running = true;
        if (!dragging)
        {
            float startT = Time.time;

            int x = Random.Range(-9, 9);
            int y = Random.Range(-2, 4);
            Vector3 dest = new Vector3(x, y, 0f);
            float journeyLength = Vector3.Distance(startPosition, dest);

            while (Time.time - startT < _seconds)
            {
                transform.position = Vector3.Lerp(startPosition, dest, ((Time.time - startT) * speed) / journeyLength);
                yield return null;
            }
            startPosition = transform.position; 
        }
        CR_running = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DiscoPecora.pecoraDx = GetComponent<Pecora>();
            print("FANCULO " + DiscoPecora.pecoraDx.sesso);
            GameManager.I.UIMng.gameplayCtrl.ShowSheepDatas(GetComponent<Pecora>(), false);

            DiscoPecora.fDx.transform.parent = DiscoPecora.pecoraDx.transform;

            GameManager.I.DiscoPecora.fDx.transform.localPosition = new Vector3(0.5f, 8, 0);
            GameManager.I.UIMng.secondSheepOff.SetActive(false);
            GameManager.I.StopCoroutine("ShutOffDx");
            GameManager.I.StartCoroutine("ShutOffDx");
        }
    }

    void OnMouseDown()
    {
        DiscoPecora.pecoraSx = GetComponent<Pecora>();
        DiscoPecora.fSx.transform.parent = DiscoPecora.pecoraSx.transform;
       DiscoPecora.fSx.transform.localPosition = new Vector3(0.5f, 8, 0);
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
        _underInertia = false;
        GameManager.I.UIMng.gameplayCtrl.ShowSheepDatas(GetComponent<Pecora>(), true);
        GameManager.I.UIMng.ActivateSpotLight1();
        GameManager.I.UIMng.firstSheepOff.SetActive(false);
        GameManager.I.StopCoroutine("ShutOffSx");
        GameManager.I.StartCoroutine("ShutOffSx");


    }

    float timer = .2f;

    void OnMouseDrag()
    {
        if (timer <= 0 || true)
        {
        //    GameManager.I.DiscoPecora.pecoraSx = null;
            Vector3 _prevPosition = _curPosition;
            _curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
            _curPosition = Camera.main.ScreenToWorldPoint(_curScreenPoint) + _offset;
            _velocity = _curPosition - _prevPosition;
            transform.position = _curPosition;
            GameManager.I.UIMng.DeactivateSpotLight1();
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
        startPosition = transform.position;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
