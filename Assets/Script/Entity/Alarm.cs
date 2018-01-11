using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FOV), typeof (StateController))] 
public class Alarm : DestructableEnitity {

    [Range(1,5)] public int reactionPriorityValue;

    [Tooltip("Use FOV script to dectect objects that active the alarm")]
    public LayerMask objectsToAlertMask;
    public LayerMask obsticleMask;

    public float sensorDectecionRadius = 5.0f;

    [SerializeField] Sprite sensorAreaGraphic;

    StateController controller;
    SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        controller = GetComponent<StateController>();
        controller.SetupStateController(true);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        stateController.SetupStateController(stats, startingState);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sensorDectecionRadius);
    }

}
