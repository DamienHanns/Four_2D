using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/WithinAttackRange")]
public class WithinAttackRangeDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool bIsWithinDistance = CheckDistance(controller);
        return bIsWithinDistance;
    }

    bool CheckDistance(StateController controller)
    {
        float disToOOI = Vector2.Distance(controller.transform.position, controller.priorityOOI.position);

        //TODO change this to check for melee range first, then go on to ranged
        if (disToOOI < controller.entityStats.attackingStats.meleeAttackRange)
        {
            return true;
        }
        else if (disToOOI < controller.entityStats.attackingStats.rangedAttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}