using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof (FOV), typeof (CircleCollider2D))]
[RequireComponent(typeof(PolyNavAgent))]
public class Charger : DestructableEnitity {

    [SerializeField] Transform waypointHolder;
    
    protected override void Start()
    {
        base.Start();
        SetupStateContoller();
    }

    protected override void SetupStateContoller()
    {
        stateController.SetupStateController(bActivateAIOnStart, stats, startingState, waypointHolder);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            IDamageable damageableObject = collision.transform.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(stats.attackingStats.meleeAttackDamage);
            }
        }
    }

    public override void React(Reactor.ReactorType reactionType, int priorityOfReaction, Transform reactorTransform = null)
    {
        //Decide what to react too
        if (priorityOfReaction > priorityOfCurrentReaction)
        {
            priorityOfCurrentReaction = priorityOfReaction;

            switch (reactionType)
            {
                case Reactor.ReactorType.Alarm:
                    //check if you want to respond to the reactor, use a priority system like def.con
                    //call transition to react to alarm state. 

                    break;
            }
        }
    }
}
