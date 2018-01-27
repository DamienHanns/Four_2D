using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateController))]
public class DestructableEnitity : MonoBehaviour, IDamageable, IReactable {

    [SerializeField] protected EntityStats stats;
    [SerializeField] protected bool bActivateAIOnStart = true;
    [SerializeField] protected State startingState;
    [SerializeField] protected ReactionStates reactionStatesContainer;   //TODO assign this at the start
    protected StateController controller;

    protected bool bIsReactiongToSomething;
    public int priorityOfCurrentReaction = 0;
    [Range (1, 10)]public int objectReactionValue = 1;

    protected float currentHealth = 1.0f;

    protected virtual void Start()
    {
        if (stats != null) { currentHealth = stats.healthStats.maxHealth; }
        else { Debug.Log(gameObject.name + ": Has no stats object attached"); }

        if (startingState == null) { Debug.Log(gameObject.name + ": Has no startingState object attached"); }
        if (reactionStatesContainer == null) { Debug.Log(gameObject.name + ": Has no reactionStates object attached"); }

        controller = GetComponent<StateController>();
    }

    protected virtual void SetupStateContoller()
    {
        controller.SetupStateController(stats, startingState, reactionStatesContainer);
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
