using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/CleanUpDeadBody")]
public class CleanUpDeadBodyAction : Action {

    public override void Act(StateController controller)
    {
        CleanUpDeadBody(controller);
    }

    void CleanUpDeadBody(StateController controller)
    {
        //TODO put clean up effact here then remove the object
        if (controller.priorityOOI != null)
        {
            controller.priorityOOI.gameObject.SetActive(false);
            controller.bPrimaryStateActionFinished = true;
        }
    }
}
