using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofScript : MonoBehaviour
{

    // The [SpineEvent] attribute makes the inspector for this MonoBehaviour
    // draw the field as a dropdown list of existing event names in your SkeletonData.
    [SpineEvent] public string poofEvent = "pouf";

    public GameObject poofTarget;

    void Start()
    {
        var anim = GetComponent<SkeletonAnimation>();
        if (anim == null) return;   // told you to add this to SkeletonAnimation's GameObject.

        // This is how you subscribe via a declared method. The method needs the correct signature.
        anim.state.Event += HandleEvent;

        anim.state.SetAnimation(0, "animation", false);

        anim.state.End += delegate {
            Destroy(gameObject);
        };

    }

    void HandleEvent(Spine.TrackEntry entry, Spine.Event e)
    {

        if (e.Data.Name == poofEvent)
        {
            GameObject.Destroy(poofTarget);
        }
    }
}
