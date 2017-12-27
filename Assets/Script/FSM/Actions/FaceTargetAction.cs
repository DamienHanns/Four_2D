using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/FaceTarget")]
public class FaceTargetAction : Action {

    public override void Act(StateController controller)
    {
        Debug.Log(controller.gameObject.name + " In stall state");
    }

}
