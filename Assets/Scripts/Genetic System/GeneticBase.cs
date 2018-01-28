using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneticBase : ScriptableObject
{

    //Gene name could be used for the Identity Card UI, and helping players identify genetic traits faster
    [SerializeField]
    string geneName;

    //Gene strength is just an enum for determining if a gene is DOMINANTI or RECESSIVI
    [SerializeField]
    GeneStrength geneStr;


    #region Get / Set

    public GeneStrength GeneStr
    {
        get
        {
            return geneStr;
        }
    }
    public string GeneName
    {
        get
        {
            return geneName;
        }
    }

    #endregion


    /// <summary>
    /// This function is designed to be called after instantiating a new sheep
    /// Its design is to automatically set any genetic specific information
    /// </summary>
    /// <param name="anim"></param>
    public abstract void SetGenetic(Pecora pecora);


}

public enum GeneStrength
{
    DOMINANTI,
    RECESSIVI
}
