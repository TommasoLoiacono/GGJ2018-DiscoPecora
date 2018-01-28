using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TestColorChange : MonoBehaviour
{
    [Header("Enable this to have the genetics update non stop")]
    [SerializeField]
    bool updateNonStop = false;

    [SerializeField]
    WoolGenetics woolGenetic;

    [SerializeField]
    SkinGenetics skinGenetic;

    [SerializeField]
    HornGenetics hornGenetic;

    [SerializeField]
    PersonalityGenetics personalityGenetic;




    // Use this for initialization
    void Start ()
    {
        woolGenetic.SetGenetic(gameObject);
        skinGenetic.SetGenetic(gameObject);
        hornGenetic.SetGenetic(gameObject);
        personalityGenetic.SetGenetic(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(updateNonStop)
        {
            woolGenetic.SetGenetic(gameObject);
            skinGenetic.SetGenetic(gameObject);
            hornGenetic.SetGenetic(gameObject);
            personalityGenetic.SetGenetic(gameObject);
        }
    }
}
