using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/ApproachObjectCasually")]
public class ApproachObjectCasuallyAction : Action {

    public override void Act(StateController controller)
    {
        if (!controller.bHasPath) { controller.StartCoroutine(Chase(controller)); }
    }

    IEnumerator Chase(StateController controller)
    {
        float repathTime = 0.2f;
        controller.bHasPath = true;

        while (controller.bHasPath)
        {
            if (controller.priorityOOI != null)
            {
                if (controller.agent.remainingDistance > 0.5f )
                {
                    controller.agent.SetDestination(controller.priorityOOI.position);   //TODO calculate ajusted position for object to stop close to the perimiter
                }
                else { controller.bPrimaryStateActionFinished = true; }
            }

            yield return new WaitForSeconds(repathTime);
        }

        controller.agent.Stop();
    }
}
