using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ChaseUntilTimerRunOut")]
public class ChaseUntilTimerRunOutDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool bTimeRanOut = controller.CheckIfCountDownElapsed(controller.entityStats.timerStats.alarmTimeTotal);
        return bTimeRanOut;
    }
}
