using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineFSM : MonoBehaviour
{
    GameObject sheep;
    [SerializeField]
    SpineAnimStates currentState;

    [SerializeField]
    SkeletonAnimation anim;

    public string selectedDance = "default-dance";

	// Use this for initialization
	void Start ()
    {
        sheep = gameObject;
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
    WalkingAlternative,
    WalkingAggressive,
    WalkingPunk,
    WalkingChic,
    WalkingYokel,

    IdleAlternative,
    IdleAggressive,
    IdlePunk,
    IdleChic,
    IdleYokel,
    
    Drag

}

        if (gameObject.GetComponent<Sheep>().dragging)
        {
            currentState = SpineAnimStates.Drag;
        }
        else
        {
                if (gameObject.GetComponent<Sheep>().CR_running)
                {
                   // currentState = SpineAnimStates.Walking;

                switch (gameObject.GetComponent<Pecora>().carattere.valoreCaratteristica) { 
                    case "Alternative":
                        currentState = SpineAnimStates.WalkingAlternative;
                    break;
                    case "Aggressive":
                        currentState = SpineAnimStates.WalkingAggressive;

                        break;
                    case "Punk":
                        currentState = SpineAnimStates.WalkingPunk;

                        break;
                    case "Chic":
                        currentState = SpineAnimStates.WalkingChic;

                        break;
                    case "Yokel":
                        currentState = SpineAnimStates.WalkingYokel;

                        break;
                    default:
                    break;
                }


            }
                else
                {
                //idle
                switch (gameObject.GetComponent<Pecora>().carattere.valoreCaratteristica)
                {
                    case "Alternative":
                        currentState = SpineAnimStates.IdleAlternative;

                        break;
                    case "Aggressive":
                        currentState = SpineAnimStates.IdleAggressive;

                        break;
                    case "Punk":
                        currentState = SpineAnimStates.IdlePunk;

                        break;
                    case "Chic":
                        currentState = SpineAnimStates.IdleChic;

                        break;
                    case "Yokel":
                        currentState = SpineAnimStates.IdleYokel;

                        break;
                    default:
                        break;
                }
            }

            
        }