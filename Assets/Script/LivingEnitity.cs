using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(StateController))]
public class LivingEnitity : MonoBehaviour, IDamageable {

    [SerializeField] protected EntityStats stats;
    [SerializeField] protected bool bActivateAIOnStart = true;
    [SerializeField] protected State startingState;
    protected StateController stateController;

    protected float currentHealth = 1.0f;

    private void Awake()
    {
        currentHealth = stats.healthStats.maxHealth;
        stateController = GetComponent<StateController>();
    }

    protected virtual void SetupStateContoller()
    {
        stateController.SetupStateController(stats);
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
}
