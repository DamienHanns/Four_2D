using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChasingAction : Action {

    public override void Act(StateController controller)
    {
        if (!controller.bHasPath) { controller.StartCoroutine(Chase(controller)); }
    }

    IEnumerator Chase(StateController controller)
    {
        float repathTime = 0.25f;
        controller.bHasPath = true;

        while (controller.bHasPath)
        {
            if (controller.priorityOOI != null)
            {
                controller.agent.SetDestination(controller.priorityOOI.position);

            }

            yield return new WaitForSeconds(repathTime);
        }

        controller.agent.Stop();
    }

}
