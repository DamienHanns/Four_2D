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
            Investagate(controller);
        }
    }

    void Investagate(StateController controller)
    {
        //what type of suspiciousObject is it
        //should that type of object be there?
        //if not which remedy should be appllied?
    }
}