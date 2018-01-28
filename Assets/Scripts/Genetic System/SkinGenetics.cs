using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinGenetic", menuName = "Genetics/Skin")]
public class SkinGenetics : GeneticBase
{


    #region Variables

    [Header("Face")]
    [SerializeField]
    Color headcolor;

    [Header("Arms")]
    [SerializeField]
    Color armcolor;

    [Header("Legs")]
    [SerializeField]
    Color legColor;

    #endregion


    public override void SetGenetic(GameObject sheepGO)
    {
        SkeletonAnimation anim = sheepGO.GetComponent<SkeletonAnimation>();


        //Left Ear
        anim.Skeleton.FindSlot("sheep-face").SetColor(headcolor);

        //Left Ear
        anim.Skeleton.FindSlot("ear").SetColor(headcolor);

        //Right Ear
        anim.Skeleton.FindSlot("ear2").SetColor(headcolor);

        //muzzle
        anim.Skeleton.FindSlot("muso").SetColor(headcolor);

        //Left Arm
        anim.Skeleton.FindSlot("limb3").SetColor(armcolor);

        //Right Arm
        anim.Skeleton.FindSlot("limb2").SetColor(armcolor);

        //Left Leg
        anim.Skeleton.FindSlot("limb4").SetColor(legColor);

        //Right Leg
        anim.skeleton.FindSlot("limb").SetColor(legColor);
        
    }

}
