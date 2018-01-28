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



    public override void SetGenetic(Pecora pecora)
    {
        throw new NotImplementedException();
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
