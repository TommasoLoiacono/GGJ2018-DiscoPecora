using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TestColorChange : MonoBehaviour
{

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

	}
	
	// Update is called once per frame
	void Update ()
    {
        woolGenetic.SetGenetic(gameObject);
        skinGenetic.SetGenetic(gameObject);
        hornGenetic.SetGenetic(gameObject);
        personalityGenetic.SetGenetic(gameObject);
    }
}
