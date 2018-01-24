using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/ReactionStatesContainer")]
public class ReactionStates : ScriptableObject {

    public State reactToPlayerState;
    public State reactToSuspiciousObjectState;
    public State reactToNeutralState;
    public State reactToAlarmState;
    public State stopReactingState;

}
