using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {

    public float SmoothTime;

    [Range(0f, 1f)]
    public float inertiaDragAmount;

    private bool _underInertia = false;
    private bool isDraggable = false;
    private bool dragging = false;
    private float distance;
    private float _time = 0f;


    // Update is called once per frame
	void Update () {

        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

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

        }
        else
        {
            if (_underInertia && _time <= SmoothTime)
            {
                transform.position = Vector3.Lerp(transform.position, p, _time);
                _time += Time.smoothDeltaTime;
            }
            else
            {
                _underInertia = false;
                _time = 0.0f;
            }
        }
    }

    private void OnMouseDrag()
    {
        dragging = true;
        _underInertia = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }



}
