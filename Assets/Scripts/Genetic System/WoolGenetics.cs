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
    Color32 headcolor;

    [Header("Body")]
    [SerializeField]
    Color32 bodycolor;

    [Header("Arms")]
    [SerializeField]
    bool armActive;
    [SerializeField]
    Color32 armcolor;

    [Header("Legs")]
    [SerializeField]
    bool legActive;
    [SerializeField]
    Color32 legColor;

    [Header("Tail")]
    [SerializeField]
    Color32 tailColor;

    #endregion


    public override void SetGenetic(Pecora pecora)
    {

    }





}




