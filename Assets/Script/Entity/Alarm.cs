using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FOV), typeof (StateController))] 
public class Alarm : DestructableEnitity {

    public enum AlarmPhase { Alarming, Caution, Detection } ;
    public AlarmPhase alarmPhase = AlarmPhase.Detection;

    [Range(1,5)] public int reactionPriorityValue;

    [Tooltip("Use FOV script to dectect objects that active the alarm")]
    public LayerMask objectsToAlertMask;
    public LayerMask obsticleMask;

    public float sensorDectecionRadius = 5.0f;
    public bool bIsAlarming = false;
    Transform offendingObjectTransform;
    [SerializeField] Sprite sensorAreaGraphic;

    StateController controller;
    SpriteRenderer spriteRenderer; Color detectionColour;

    protected override void Start()
    {
        base.Start();
        controller = GetComponent<StateController>();
        controller.SetupStateController(true);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.transform.localScale =  new Vector3 (controller.fov.viewRadius * 2, controller.fov.viewRadius * 2, 0);
        detectionColour = spriteRenderer.color;
        stateController.SetupStateController(stats, startingState);
    }

    public void ChangeAlarmRadiusColour()
    {
        switch (alarmPhase)
        {
            case AlarmPhase.Detection:
                spriteRenderer.color = detectionColour;
                break;

            case AlarmPhase.Caution:
                spriteRenderer.color = Color.yellow;
                break;

            case AlarmPhase.Alarming:
                spriteRenderer.color = Color.red;
                break;

            default:
                Debug.LogWarning("Alarm switch out range");
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sensorDectecionRadius);
    }

}
