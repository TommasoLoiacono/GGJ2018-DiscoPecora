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

    public string selectedDance = "default-dance";

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
        //Incase we need to do something during a animation state
        //Currently i have nothing planned
        switch(currentState)
        {
            case SpineAnimStates.Dancing:
                break;
            case SpineAnimStates.Loving:
                break;
            case SpineAnimStates.Walking:
                break;
            case SpineAnimStates.Idle:
                break;
        }
    }

    public void ChangeAnimationState(SpineAnimStates nextState)
    {
        switch (nextState)
        {
            case SpineAnimStates.Dancing:
                anim.AnimationState.SetAnimation(0, selectedDance, true);
                break;
            case SpineAnimStates.Loving:
                anim.AnimationState.SetAnimation(0, "make-love", true);
                break;
            case SpineAnimStates.Walking:
                anim.AnimationState.SetAnimation(0, "walking", true);
                break;
            case SpineAnimStates.Idle:
                anim.AnimationState.SetAnimation(0, "idle", true);
                break;
        }
    }
    

}

public enum SpineAnimStates
{
    Dancing,
    Loving,
    Walking,
    Idle

}
