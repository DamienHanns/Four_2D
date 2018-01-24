using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/InvestagatePlayer")]
public class InvestagatePlayerAction : Action
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
        //is it the attual player avater or somehting else
        //should the be there?
        //if not which remedy should be appllied?
        //how hostile should the player be treated
    }
}