using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour {

    public void MoveSpotLightToPosition(Vector3 _position)
    {
        Vector3 tempobjPos = Camera.main.WorldToScreenPoint(_position); // la posizione dell'oggetto da seguire, sul canvasa.
        transform.position = tempobjPos;
    }
}
