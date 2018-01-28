using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofScript : MonoBehaviour
{

    // The [SpineEvent] attribute makes the inspector for this MonoBehaviour
    // draw the field as a dropdown list of existing event names in your SkeletonData.
    [SpineEvent] public string poofEvent = "pouf";

    [SerializeField]
    SkeletonAnimation anim;


    void Start()
    {
        anim = GetComponent<SkeletonAnimation>();
        if (anim == null) return;   // told you to add this to SkeletonAnimation's GameObject.

        // This is how you subscribe via a declared method. The method needs the correct signature.
        //anim.state.Event += HandleEvent;

        //Instantiate Poof game object then call GetComponent<SkeletonAnimation>(); for poof gameobject
        //Then add this lambda expression
        //Then just call play animation
        //anim.state.Event += (Spine.TrackEntry entity, Spine.Event e) =>
        //{
        //    //inside the lambda call destroy on your target or instantiate
        //    //if you are spawning a new sheep in
        //    if (e.Data.Name == poofEvent)
        //    {
        //        GameObject.Destroy(poofTarget);
        //    }
        //};

        //anim.state.SetAnimation(0, "animation", false);

        anim.state.End += delegate {
            Destroy(gameObject);
        };

    }

    public void PlayAnimation()
    {
        anim.state.SetAnimation(0, "animation", false);
    }

    void HandleEvent(Spine.TrackEntry entry, Spine.Event e)
    {

        
    }
}
