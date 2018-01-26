using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/ApproachObjectCasually")]
public class ApproachObjectCasuallyAction : Action {

    public override void Act(StateController controller)
    {
        if (!controller.bHasPath) { controller.StartCoroutine(Chase(controller)); }

        if (controller.agent.remainingDistance < 2.0f)
        {
            controller.StopCoroutine(Chase(controller));
            controller.agent.Stop();
            controller.bPrimaryStateActionFinished = true;
        }
    }

    IEnumerator Chase(StateController controller)
    {
        float repathTime = 0.2f;
        controller.bHasPath = true;

        controller.agent.SetDestination(controller.priorityOOI.position);

        while (controller.bHasPath)
        {
            if (controller.priorityOOI != null)
            {
                    controller.agent.SetDestination(controller.priorityOOI.position);   //TODO calculate ajusted position for object to stop close to the perimiter        
            }

            yield return new WaitForSeconds(repathTime);
        }

        controller.agent.Stop();
    }
}
