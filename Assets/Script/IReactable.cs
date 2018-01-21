using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReactable {

    void React(Reactor.ReactorType reactionToType, int priorityOfReaction, Transform reactorTransform = null);

    void React(Reactor.ReactorType reactionToType, int priorityOfReaction, Transform transformToReactTo, Transform transformCallingReaction = null);

}
