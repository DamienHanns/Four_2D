using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/CheckObjectType")]
public class CheckObjectTypeAction : Action
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
        CheckOOIs(controller);     
    }

    void CheckOOIs(StateController controller)      //check list in FOV script for what needs to be reacted to
    {
        foreach (Transform target in controller.fov.visableTagets)
        {
            if (target != null)
            {
                if (LayerMask.NameToLayer("Player") == target.gameObject.layer)
                {
                    controller.priorityOOI = target;
                    if (controller.reactionStatesContainer.reactToPlayerState != null)
                    {
                        controller.TransitionToState(controller.reactionStatesContainer.reactToPlayerState);
                    }
                    else { Debug.LogWarning("Player reaction state not assisned on: " + controller.name); }

                    break;
                }

                else if (LayerMask.NameToLayer("Neutral") == target.gameObject.layer)
                {
                    controller.priorityOOI = target;
                    if (controller.reactionStatesContainer.reactToNeutralState != null)
                    {
                        controller.TransitionToState(controller.reactionStatesContainer.reactToNeutralState);
                    }
                    else { Debug.LogWarning("Neutral reaction state not assisned on: " + controller.name); }

                    break;
                }

                else if (LayerMask.NameToLayer("SuspiciousObject") == target.gameObject.layer)
                {
                    controller.priorityOOI = target;
                    if (controller.reactionStatesContainer.reactToSuspiciousObjectState != null)
                    {
                        controller.TransitionToState(controller.reactionStatesContainer.reactToSuspiciousObjectState);
                    }
                    else { Debug.LogWarning("Suspicious reaction state not assisned on: " + controller.name); }

                    break;
                }
            }
        }
    }
}
