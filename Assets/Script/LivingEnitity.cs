using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEnitity : MonoBehaviour, IDamageable {

    [SerializeField] protected Stats stats;
    protected float currentHealth = 1.0f;

    private void Awake()
    {
        currentHealth = stats.maxHealth;
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
