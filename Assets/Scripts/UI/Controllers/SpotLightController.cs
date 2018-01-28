using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour {

    Pecora target;

    public void MoveSpotLightToPosition(Pecora _pecoraToFollow)
    {
        target = _pecoraToFollow;
    }

    private void Update()
    {
        if(target != null)
        {
            Vector3 tempobjPos = Camera.main.WorldToScreenPoint(target.transform.position); // la posizione dell'oggetto da seguire, sul canvasa.
            transform.position = tempobjPos;
        }
    }
}
