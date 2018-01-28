using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonalityGenetic", menuName = "Genetics/Personality")]
public class PersonalityGenetics : GeneticBase
{
    [Header("Personality type is just what type of clothing they wear, description can be used inside the identity card")]
    [Header("Personality Type")]
    [SerializeField]
    PersonalityTypes personality;
    //Could use description for helping add info to the identity card
    [SerializeField]
    [TextArea]
    string description;

    public string Description
    {
        get
        {
            return description;
        }
    }

    public PersonalityTypes Personality
    {
        get
        {
            return personality;
        }
    }

    public override void SetGenetic(GameObject sheepGO)
    {

        SkeletonAnimation anim = sheepGO.GetComponent<SkeletonAnimation>();

        MakeNaked(anim);


        switch(personality)
        {
            case PersonalityTypes.alternativo:
                break;
            case PersonalityTypes.aggressivo:
                break;
            case PersonalityTypes.yokel:
                break;
            case PersonalityTypes.chic:
                break;
            case PersonalityTypes.punkabbestia:
                break;
        }
    }

    private void MakeNaked(SkeletonAnimation anim)
    {
        anim.skeleton.SetAttachment("occhiali-hippie", null);
        anim.skeleton.SetAttachment("head-accessories", null);
        anim.skeleton.SetAttachment("earrings2", null);
        anim.skeleton.SetAttachment("earrings", null);
        anim.skeleton.SetAttachment("headphones", null);
        anim.skeleton.SetAttachment("mouth-piercing", null);
        anim.skeleton.SetAttachment("collare-punk", null);
        anim.skeleton.SetAttachment("collana-hippie", null);
        anim.skeleton.SetAttachment("belt-tamarro-pelo", null);
        anim.skeleton.SetAttachment("belt-tamarro", null);
        anim.skeleton.SetAttachment("shoes2", null);
        anim.skeleton.SetAttachment("shoes", null);
    }
}

public enum PersonalityTypes
{
    alternativo,
    aggressivo,
    yokel,
    chic,
    punkabbestia
}
