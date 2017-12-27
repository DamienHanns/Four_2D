using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ActionFinished")]
public class ActionFinishedDecision : Decision {

	public override bool Decide(StateController controller)
    {
        bool bActionFinished = controller.bPrimaryStateActionFinished;
        return bActionFinished;
    }
}
