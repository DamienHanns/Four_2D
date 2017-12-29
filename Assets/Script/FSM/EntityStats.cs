using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Stats/EntityStats")]
public class EntityStats :ScriptableObject {

    public HealthStats healthStats;
    public AttackingStats attackingStats;
    public MovementStats movementStats;
    public TimerStats timerStats;

}
