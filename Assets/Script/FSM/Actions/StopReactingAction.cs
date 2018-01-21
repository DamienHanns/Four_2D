using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/StopReacting")]
public class StopReactingAction : Action {

    public override void Act(StateController controller)
    {
        if ( ! controller.bPrimaryStateActionFinished)
        {
            DestructableEnitity dEnitity = controller.transform.GetComponent<DestructableEnitity>();
            if (dEnitity != null) dEnitity.StopReacting();

            controller.bPrimaryStateActionFinished = true;
        }
    }
}
