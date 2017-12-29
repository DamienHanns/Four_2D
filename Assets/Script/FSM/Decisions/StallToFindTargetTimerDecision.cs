using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/StallToFindTargetTimer")]
public class StallToFindTargetTimerDecision : Decision {

    public override bool Decide(StateController controller)
    {
       bool bTimerRanOut = controller.CheckIfCountDownElapsed(controller.entityStats.timerStats.findTargetStallTime);
        return bTimerRanOut;
    }
}
