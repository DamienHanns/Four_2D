using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Timer")]
public class TimerStats : ScriptableObject {
    public float stallTime;
    public float findTargetStallTime;

    public float alarmTimeTotal;
    public float chaseTimeTotal;
}
