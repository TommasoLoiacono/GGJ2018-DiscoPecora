using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ScriptableObject class for saving different Wool Genetics
/// Legs and arms can be disabled to there is no wool there.. adding more variations
/// </summary>
[CreateAssetMenu(fileName = "WoolGenetic", menuName = "Genetics/Wool")]
public class WoolGenetics : GeneticBase
{

    #region Variables

    [Header("Head")]
    [SerializeField]
    Color headcolor;

    [Header("Body")]
    [SerializeField]
    Color bodycolor;

    [Header("Arms")]
    [SerializeField]
    bool armActive;
    [SerializeField]
    Color armcolor;

    [Header("Legs")]
    [SerializeField]
    bool legActive;
    [SerializeField]
    Color legColor;

    [Header("Tail")]
    [SerializeField]
    Color tailColor;

    #endregion


    public override void SetGenetic(GameObject sheepGO)
    {

        SkeletonAnimation anim = sheepGO.GetComponent<SkeletonAnimation>();
        
       
        //Right Arm
        anim.Skeleton.FindSlot("sheep-arm-up2").SetColor(armcolor);

        //Left Arm
        anim.Skeleton.FindSlot("sheep-arm-up").SetColor(armcolor);

        //Left Leg
        anim.Skeleton.FindSlot("leg-up-sheep4").SetColor(legColor);

        //Right Leg
        anim.Skeleton.FindSlot("leg-up-sheep").SetColor(legColor);

        //Body
        anim.Skeleton.FindSlot("body").SetColor(bodycolor);

        //Head
        anim.Skeleton.FindSlot("head-sheep").SetColor(headcolor);

        //Tail
        anim.skeleton.FindSlot("tail").SetColor(tailColor);

        //Sets the arm / leg alpha to 0 so the slot will not show
        //There is a better way however to save time im not looking it up for now
        if (!armActive)
        {
            anim.skeleton.FindSlot("sheep-arm-up2").SetColor(new Color(0, 0, 0, 0));
            anim.skeleton.FindSlot("sheep-arm-up").SetColor(new Color(0, 0, 0, 0));
        }

        if (!legActive)
        {
            anim.skeleton.FindSlot("leg-up-sheep4").SetColor(new Color(0, 0, 0, 0));
            anim.skeleton.FindSlot("leg-up-sheep").SetColor(new Color(0, 0, 0, 0));
        }


    }





}




