using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/InvestagateSuspiciousObject")]
public class InvestagateSuspiciousObjectAction : Action
{
    public override void Act(StateController controller)
    {
        if (!controller.bHasStatedAction)
        {
            controller.bHasStatedAction = true;
            Investagate(controller);
        }
    }

    void Investagate(StateController controller)
    {
        Debug.Log("SO is being investagated");

        switch (controller.priorityOOI.tag)
        {
            case "DeadBody":
                Debug.Log("Goto deal with dead body state");   
                controller.TransitionToState(controller.investagateSOStatesContainer.InvestagateDeadBodyState);
                break;

            default: Debug.Log("Investagytion switch for SO defulted on: " + controller.name);
                break;
        }
    }

}