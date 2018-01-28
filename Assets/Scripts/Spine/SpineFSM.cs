using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineFSM : MonoBehaviour
{

    [SerializeField]
    SpineAnimStates currentState;

    [SerializeField]
    SkeletonAnimation anim;

	// Use this for initialization
	void Start ()
    {
        currentState = SpineAnimStates.Idle;
        anim.GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateState();
	}

    private void UpdateState()
    {
        
    }

    public void ChangeAnimationState(SpineAnimStates nextState)
    {
        currentState = nextState;
        anim.AnimationState.SetAnimation(0, currentState.ToString(), true);
    }

}

public enum SpineAnimStates
{
    Dancing,
    Loving,
    Walking,
    Idle

}
