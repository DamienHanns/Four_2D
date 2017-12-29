using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/StallTimer")]
public class StallTimerDecision : Decision {

    public override bool Decide(StateController controller)
    {
       bool bTimeRanOut = controller.CheckIfCountDownElapsed(controller.entityStats.timerStats.stallTime);
       return bTimeRanOut;
    }

}
