using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardMovement : MonoBehaviour {

    RectTransform rect;
    RectTransform canvas;
    Vector3 startingPos;
    SheepDisplayer displayer;
    public Image MiniatureImage;

    bool _isOpen;

	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();
        displayer = GetComponent<SheepDisplayer>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPos = transform.position;
	}

    void MoveCard(bool _isOpening)
    {
        if (!_isOpen)
        {
            transform.DOMove(new Vector3(startingPos.x, canvas.rect.height - rect.rect.height / 2, startingPos.z), 1);
        }
        else
        {
            transform.DOMove(new Vector3(startingPos.x, startingPos.y, startingPos.z), 1);
        }
    }

    public void OpenCloseCard()
    {
        MoveCard(_isOpen);
        MiniatureImage.enabled = _isOpen;
        displayer.SheepText.enabled = !_isOpen;
        _isOpen = !_isOpen;
    }
}
