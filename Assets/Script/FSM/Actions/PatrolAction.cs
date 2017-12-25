using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action {

    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    void Patrol(StateController controller)
    {

    }
}
