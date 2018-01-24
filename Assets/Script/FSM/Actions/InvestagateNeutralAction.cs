using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/InvestagateNeutral")]
public class InvestagateNeutralAction : Action
{

    public override void Act(StateController controller)
    {
        if (!controller.bHasStatedAction)
        {
            Investagate(controller);
        }
    }

    void Investagate(StateController controller)
    {
        //Type of neutral?
        //should the neutral be there?
        //if not which remedy should be appllied?
        //how hostile should the player be treated
    }
}