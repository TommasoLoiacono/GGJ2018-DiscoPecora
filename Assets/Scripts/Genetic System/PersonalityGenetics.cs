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
        SpineFSM fsm = sheepGO.GetComponent<SpineFSM>();

        MakeNaked(anim);


        switch(personality)
        {
            case PersonalityTypes.alternativo:
                //little flower on the head, hippie necklace with the symbol of the peace, john lennon glasses
                
                if (UnityEngine.Random.Range(1, 100) >= 50)
                    anim.skeleton.SetAttachment("occhiali-hippie", "occhiali-hippie");
                else
                    anim.skeleton.SetAttachment("occhiali-hippie", "tamarro-glasses");

                anim.skeleton.SetAttachment("head-accessories", "flower");
                anim.skeleton.SetAttachment("collana-hippie", "collana-hippie");

                fsm.selectedDance = "disco";

                break;
            case PersonalityTypes.aggressivo:
                //cigarette, bandana, boots

                anim.skeleton.SetAttachment("head-accessories", "bandana");
                anim.skeleton.SetAttachment("sigaretta", "sigaretta");
                anim.skeleton.SetAttachment("shoes2", "stivale-1");
                anim.skeleton.SetAttachment("shoes", "stivale-1");

                fsm.selectedDance = "rock";

                break;
            case PersonalityTypes.yokel:
                //air max, glasses with stripes, the belt with the dollar
                anim.skeleton.SetAttachment("occhiali-hippie", "tamarro-glasses");
                anim.skeleton.SetAttachment("shoes2", "elegant-shoes");
                anim.skeleton.SetAttachment("shoes", "elegant-shoes");

                fsm.selectedDance = "rave";

                break;
            case PersonalityTypes.chic:
                //heels / pointy shoes, tie / earrings
                anim.skeleton.SetAttachment("cravatta", "cravatta");
                anim.skeleton.SetAttachment("shoes2", "heels");
                anim.skeleton.SetAttachment("shoes", "heels");

                fsm.selectedDance = "napolian dynomite";

                break;
            case PersonalityTypes.punkabbestia:
                //necklace with studs, rainbow crest, lip earring
                anim.skeleton.SetAttachment("head-accessories", "irokese");
                anim.skeleton.SetAttachment("mouth-piercing", "mouth-piercing");
                anim.skeleton.SetAttachment("collare-punk", "collare-punk");
                anim.skeleton.SetAttachment("belt-tamarro", "belt-tamarro");
                anim.skeleton.SetAttachment("shoes2", "sneakers");
                anim.skeleton.SetAttachment("shoes", "sneakers");

                fsm.selectedDance = "headbang";

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
        anim.skeleton.SetAttachment("sigaretta", null);
        anim.skeleton.SetAttachment("cravatta", null);
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
