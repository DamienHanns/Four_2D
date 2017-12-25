using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/State")]
public class State : ScriptableObject {

    public Action[] actions;

    public Color stateIndicatorColour;

    public void ExecuteState(StateController controller)
    {
        DoActions(controller);
    }

    void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }
}
