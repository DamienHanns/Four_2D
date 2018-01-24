using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ReturnTrue")]
public class ReturnTrueDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return true;
    }
}

