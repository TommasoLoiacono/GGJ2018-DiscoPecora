using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {

    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;

    private bool isDraggable = false;
    private bool dragging = false;
    private float distance;


    // Update is called once per frame
	void Update () {



        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        if (dragging)
        {
            Vector3 p = new Vector3();
            Camera c = Camera.main;
            Vector2 mousePos = new Vector2();

            // Get the mouse position from Event.
            // Note that the y position from Event is inverted.
            mousePos.x = Input.mousePosition.x;
            mousePos.y = c.pixelHeight - Input.mousePosition.y;

            p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));
            p.y = -p.y;
            transform.position = p;
        }
    }

    private void OnMouseDrag()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }



}
