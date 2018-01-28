using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

[CreateAssetMenu(fileName = "HornGenetic", menuName = "Genetics/Horn")]
public class HornGenetics : GeneticBase
{

    [SerializeField]
    HornType leftHorn;

    [SerializeField]
    HornType rightHorn;

    [SerializeField]
    Color hornColor;


    public override void SetGenetic(GameObject sheepGO)
    {
        SkeletonAnimation anim = sheepGO.GetComponent<SkeletonAnimation>();

        anim.skeleton.SetAttachment("horn2", leftHorn.ToString());
        anim.Skeleton.FindSlot("horn2").SetColor(hornColor);

        anim.skeleton.SetAttachment("horn1", rightHorn.ToString());
        anim.Skeleton.FindSlot("horn1").SetColor(hornColor);
    }
    
}

public enum HornType
{
    horn1,
    horn2,
    horn3,
    None
}