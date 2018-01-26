using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(FOV), typeof(CircleCollider2D))]
[RequireComponent(typeof(PolyNavAgent))]
public class Charger : DestructableEnitity
{
    [SerializeField] Transform waypointHolder;

    protected override void Start()
    {
        base.Start();
        SetupStateContoller();
    }

    protected override void SetupStateContoller()
    {
        controller.SetupStateController(bActivateAIOnStart, stats, startingState, reactionStatesContainer, waypointHolder);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") || collision.gameObject.layer == LayerMask.NameToLayer("Nuteral"))
        {
            IDamageable damageableObject = collision.transform.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(stats.attackingStats.meleeAttackDamage);
            }
        }
    }


    //TODO put this into a State. Make a ReactToSomething decision
    public override void React(Reactor.ReactorType reactionType, int priorityOfReaction, Transform transformToReactTo, Transform reactorTransform = null)
    {
        if (priorityOfReaction > priorityOfCurrentReaction)
        {
            priorityOfCurrentReaction = priorityOfReaction;

            if (!bIsReactiongToSomething) { bIsReactiongToSomething = true; }

            switch (reactionType)
            {
                case Reactor.ReactorType.Alarm:
                    controller.priorityOOI = transformToReactTo;
                    controller.TransitionToState(reactionStatesContainer.reactToAlarmState);
                    print(controller.priorityOOI);
                    break;
            }
        }
    }
    
}
