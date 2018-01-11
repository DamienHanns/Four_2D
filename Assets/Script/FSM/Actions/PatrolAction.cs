using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action {

    [SerializeField] float pauseTimeAtEndOfRoute = 0.0f;

    public override void Act(StateController controller)
    {
        if ( ! controller.bHasPath )controller.StartCoroutine(Patrol(controller));
    }

    IEnumerator Patrol(StateController controller)
    {
        float repathTime = 0.25f;

        Vector3 nextWaypoint = controller.waypoints[controller.nextWaypointIndex];
        Vector3 previousWaypoint = Vector3.zero;

        controller.agent.SetDestination(nextWaypoint);

        controller.bHasPath = true;     //TODO change this bool and change the condition for the while loop.
        while (controller.bHasPath)
        {

            if (controller.agent.remainingDistance <= controller.agent.slowingDistance / 2)
            {
                if (controller.bIsCyclicalPath)             //TODO switch on and off after a number patrols to introduce randomness
                {
                    controller.nextWaypointIndex++;

                    if (controller.nextWaypointIndex >= controller.waypoints.Length)
                    {
                        controller.nextWaypointIndex = 0;
                        yield return new WaitForSeconds(pauseTimeAtEndOfRoute);
                    }

                    nextWaypoint = controller.waypoints[controller.nextWaypointIndex];
                    controller.agent.SetDestination(nextWaypoint);

                    
                }
                else
                {
                    controller.nextWaypointIndex++;

                    if (controller.nextWaypointIndex >= controller.waypoints.Length)
                    {
                        controller.nextWaypointIndex = 0;
                        System.Array.Reverse(controller.waypoints);
                        yield return new WaitForSeconds(pauseTimeAtEndOfRoute);
                    }
                    nextWaypoint = controller.waypoints[controller.nextWaypointIndex];
                    controller.agent.SetDestination(nextWaypoint);
                }
            }
            yield return new WaitForSeconds(repathTime);

        }

        controller.agent.Stop();
    }
}
