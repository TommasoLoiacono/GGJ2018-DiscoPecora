using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TestColorChange : MonoBehaviour
{

    

    [SerializeField]
    SkeletonAnimation anim;


	// Use this for initialization
	void Start ()
    {

        anim = GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
}
