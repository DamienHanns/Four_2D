using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AlarmWithinRadius")]
public class AlarmWithinRadiusAction : Action {
    
    //TODO add other limitations, such as alarm within and area boundery e.g. one room and not another.
    //TODO cause reactions in other objects within LOS

    public override void Act(StateController controller)
    {
        if ( ! controller.bHasStatedAction) { controller.StartCoroutine(SoundAlarm(controller)); }
    }

    IEnumerator SoundAlarm(StateController controller)
    {
        controller.bHasStatedAction = true;
        float alarmAgainTIme = 0.2f;
        Alarm sensor = controller.GetComponent<Alarm>();
       
        if (sensor != null)
        {
            while (controller.bHasStatedAction)
            {
                
                Collider2D[] objectsInAlarmSoundRadius = Physics2D.OverlapCircleAll(controller.transform.position, sensor.sensorDectecionRadius, sensor.objectsToAlertMask);
                for (int i = 0; i < objectsInAlarmSoundRadius.Length; ++i)
                {
                    IReactable reactableObject = objectsInAlarmSoundRadius[i].GetComponent<IReactable>();
                    if (reactableObject != null)
                    {
                        reactableObject.React(Reactor.ReactorType.Alarm, sensor.reactionPriorityValue, controller.transform);
                    }
                    else { Debug.Log("IReactable = null on object : " + objectsInAlarmSoundRadius[i].gameObject.name); }
                    
                }
                yield return new WaitForSeconds(alarmAgainTIme);
            }
        }
    }

}
