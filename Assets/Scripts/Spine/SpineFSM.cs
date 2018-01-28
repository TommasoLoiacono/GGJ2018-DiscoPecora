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

    // Use this for initialization
    void Start()
    {
        sheep = gameObject;
        anim.GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (gameObject.GetComponent<Sheep>().dragging)
        {
            currentState = SpineAnimStates.Drag;
        }
        else
        {
            if (gameObject.GetComponent<Sheep>().CR_running)
            {
                // currentState = SpineAnimStates.Walking;

                switch (gameObject.GetComponent<Pecora>().carattere.valoreCaratteristica)
                {
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
    }

    public void ChangeAnimationState(SpineAnimStates nextState)
    {
        currentState = nextState;
        anim.AnimationState.SetAnimation(0, currentState.ToString(), true);
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
