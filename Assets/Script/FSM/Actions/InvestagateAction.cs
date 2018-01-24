using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Investage")]
public class InvestagateAction : Action
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
        controller.bHasStatedAction = true;
        CheckOOIs(controller);        // TODO ?? pass a priority value into the investagting object. A low value ??
    }

    void CheckOOIs(StateController controller)
    {
        foreach (Transform target in controller.fov.visableTagets)
        {
            if (target != null)
            {
                if (LayerMask.NameToLayer("Player") == target.gameObject.layer)
                {
                    controller.priorityOOI = target;
                    if (controller.reactionStates.reactToPlayerState != null)
                    {
                        controller.TransitionToState(controller.reactionStates.reactToPlayerState);
                    }
                    else { Debug.LogWarning("Player reaction state not assisned on: " + controller.name); }

                    break;
                }

                else if (LayerMask.NameToLayer("Neutral") == target.gameObject.layer)
                {
                    controller.priorityOOI = target;
                    if (controller.reactionStates.reactToNeutralState != null)
                    {
                        controller.TransitionToState(controller.reactionStates.reactToNeutralState);
                    }
                    else { Debug.LogWarning("Neutral reaction state not assisned on: " + controller.name); }

                    break;
                }

                else if (LayerMask.NameToLayer("SuspiciousObject") == target.gameObject.layer)
                {
                    controller.priorityOOI = target;
                    if (controller.reactionStates.reactToSuspiciousObjectState != null)
                    {
                        controller.TransitionToState(controller.reactionStates.reactToSuspiciousObjectState);
                    }
                    else { Debug.LogWarning("Suspicious reaction state not assisned on: " + controller.name); }

                    break;
                }
            }
        }
    }
}
