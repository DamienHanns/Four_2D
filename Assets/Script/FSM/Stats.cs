using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : ScriptableObject {
    [SerializeField] float moveSpeed;
    [SerializeField] float chaseSpeed;
    [SerializeField] float chargeSpeed;

    public float stallTime;
    public float attackRange;
}
