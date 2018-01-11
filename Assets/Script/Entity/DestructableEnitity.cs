using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(StateController))]
public class DestructableEnitity : MonoBehaviour, IDamageable, IReactable {

    [SerializeField] protected EntityStats stats;
    [SerializeField] protected bool bActivateAIOnStart = true;
    [SerializeField] protected State startingState;
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

    public virtual void React(Reactor.ReactorType reactionType, int priorityOfReaction, Transform reactorTransform = null)
    {

    }
}
