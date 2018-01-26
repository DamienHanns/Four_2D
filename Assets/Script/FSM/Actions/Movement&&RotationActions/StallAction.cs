using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Stall")]
public class StallAction : Action {

    public override void Act(StateController controller)
    {
        Debug.Log(controller.gameObject.name + " In Stalling Action");
    }

}
