using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/LookForTargetsDecision")]
public class LookForTargetsDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool bCanSeeOOI = Look(controller);
        return bCanSeeOOI;
    }

    bool Look(StateController controller)
    {
        if (controller.fov.bIsTargetInLOS)
        {
            return true;
        }
        return false;
    }
}
