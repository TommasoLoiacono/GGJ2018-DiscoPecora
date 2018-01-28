using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girandola : MonoBehaviour {

    public float speed = 10f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f,0f,speed));
	}
}
