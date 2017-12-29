using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Distance")]
public class DistanceDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool bIsWithinDistance = CheckDistance(controller);
        return bIsWithinDistance;
    }

    bool CheckDistance(StateController controller)
    {
        float disToOOI = Vector2.Distance(controller.transform.position, controller.priorityOOI.position);

        if (disToOOI < controller.entityStats.attackingStats.rangedAttackRange)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
