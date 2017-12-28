using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof (FOV), typeof (CircleCollider2D))]
[RequireComponent(typeof(PolyNavAgent), typeof (StateController))]
public class Charger : LivingEnitity {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            IDamageable damageableObject = collision.transform.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(stats.attackDamage);
            }
        }
    }

}
