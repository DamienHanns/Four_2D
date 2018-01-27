using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/CheckForHighestPriorityIssue")]
public class CheckForHighestPriorityIssueAction : Action
{
    public override void Act(StateController controller)
    {
        if (!controller.bIsCheckingForHighierPriorities) { controller.StartCoroutine(CheckForHighierPriorityIssues(controller)); }
    }

    IEnumerator CheckForHighierPriorityIssues(StateController controller)
    {
        float refreshTime = 0.1f;
        DestructableEnitity mydEntity = controller.transform.GetComponent<DestructableEnitity>();

        while (true)
        {
            if (controller.fov.bIsTargetInLOS)
            {
                CheckOOIs(controller, mydEntity);
            }

            yield return new WaitForSeconds(refreshTime);
        }
    }

    void CheckOOIs(StateController controller, DestructableEnitity mydEntity)      //check list in FOV script for what needs to be reacted to
    {
        Transform newooi = null;       //use this to assign the highest prioity transform, then pass it to a checking fuction.

        for (int i = 0; i < controller.fov.visableTagets.Count; i++)
        {
            Transform ooi = controller.fov.visableTagets[i].transform;
            DestructableEnitity otherdEntity = ooi.GetComponent<DestructableEnitity>();

            if (otherdEntity != null)
            {
                int otherReactionValue = otherdEntity.objectReactionValue;
                if (otherReactionValue > mydEntity.priorityOfCurrentReaction)
                {
                    mydEntity.priorityOfCurrentReaction = otherReactionValue;
                    newooi = ooi;
                }
            }
        }

        if (newooi !=null) { AssignNewOOI(controller, newooi); }
    }

    void AssignNewOOI(StateController controller, Transform newooi)
    {
        LayerMask ooiLayer = newooi.gameObject.layer;

        if (LayerMask.NameToLayer("Player") == ooiLayer)
        {
            controller.priorityOOI = newooi;
            if (controller.reactionStatesContainer.reactToPlayerState != null)
            {
                controller.TransitionToState(controller.reactionStatesContainer.reactToPlayerState);
            }
            else { Debug.LogWarning("Player reaction state not assisned on: " + controller.name); }
        }
        else if (LayerMask.NameToLayer("Neutral") == ooiLayer)
        {
            controller.priorityOOI = newooi;
            if (controller.reactionStatesContainer.reactToNeutralState != null)
            {
                controller.TransitionToState(controller.reactionStatesContainer.reactToNeutralState);
            }
            else { Debug.LogWarning("Neutral reaction state not assisned on: " + controller.name); }
        }
        else if (LayerMask.NameToLayer("SuspiciousObject") == ooiLayer)
        {
            controller.priorityOOI = newooi;
            if (controller.reactionStatesContainer.reactToSuspiciousObjectState != null)
            {
                controller.TransitionToState(controller.reactionStatesContainer.reactToSuspiciousObjectState);
            }
            else { Debug.LogWarning("SuspiciousObject reaction state not assisned on: " + controller.name); }
        }
        else
        {
            Debug.Log(controller.name + ": Found higher priority to react to but was unable to go to a state to handle it");
        }
    }

}
