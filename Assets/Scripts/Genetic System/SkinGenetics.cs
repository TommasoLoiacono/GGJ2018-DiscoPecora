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
    Color32 headcolor;

    [Header("Arms")]
    [SerializeField]
    Color32 armcolor;

    [Header("Legs")]
    [SerializeField]
    Color32 legColor;

    #endregion


    public override void SetGenetic(Pecora pecora)
    {
        throw new NotImplementedException();
    }

}
