using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateController))]
public class DestructableEnitity : MonoBehaviour, IDamageable, IReactable {
    
    public enum InvestagetionFound { Player, Neural, Enemy, SuspiciousObject };
    public InvestagetionFound investagationFound;

    [SerializeField] protected EntityStats stats;
    [SerializeField] protected bool bActivateAIOnStart = true;
    [SerializeField] protected State startingState;
    [SerializeField] protected ReactionStates reactionStates;   //TODO assign this at the start
    protected StateController stateController;

    protected bool bIsReactiongToSomething;
    protected int priorityOfCurrentReaction;

    protected float currentHealth = 1.0f;

    protected virtual void Start()
    {
        if (stats != null) { currentHealth = stats.healthStats.maxHealth; }
        else { Debug.Log(gameObject.name + ": Has no stats object attached"); }

        if (startingState == null) { Debug.Log(gameObject.name + ": Has no startingState object attached"); }

        stateController = GetComponent<StateController>();
    }

    protected virtual void SetupStateContoller()
    {
        stateController.SetupStateController(stats, startingState);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0.0f;
            gameObject.SetActive(false);
        }
    }

    public void StopReacting()
    {
        bIsReactiongToSomething = false;
        SetPriorityOfCurrentReactionValue(0);
    }

    public void SetPriorityOfCurrentReactionValue(int valueToSetTo)
    {
        priorityOfCurrentReaction = valueToSetTo;
    }

    public virtual void Investage()
    {
        Debug.Log("investagtion called, but method not extended on: " + gameObject.name);
    }

    public virtual void React(Reactor.ReactorType reactionType, int priorityOfReaction, Transform reactorTransform = null)
    {

    }
    public virtual void React(Reactor.ReactorType reactionToType, int priorityOfReaction, Transform transformToReactTo, Transform transformCallingReaction = null)
    {

    }
}
