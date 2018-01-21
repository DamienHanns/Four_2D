using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Stats/Attacking")]
public class AttackingStats : ScriptableObject {

    public float meleeAttackDamage;
    public float meleeAttackRange;

    public float rangedAttackDamage;
    public float rangedAttackRange;

    public float chargeSpeed;
}
