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
        Alarm alarm = controller.GetComponent<Alarm>();
       
        if (alarm != null)
        {
            alarm.alarmPhase = Alarm.AlarmPhase.Alarming;
            alarm.ChangeAlarmRadiusColour();

            controller.onExitState += alarm.ChangeAlarmRadiusColour;
            
            while (controller.bHasStatedAction)
            {
                Collider2D[] objectsInAlarmSoundRadius = Physics2D.OverlapCircleAll(controller.transform.position, alarm.sensorDectecionRadius, alarm.objectsToAlertMask);
                for (int i = 0; i < objectsInAlarmSoundRadius.Length; ++i)
                {
                    IReactable reactableObject = objectsInAlarmSoundRadius[i].GetComponent<IReactable>();
                    if (reactableObject != null)
                    {
                        if (controller.fov.visableTagets.Count > 0)
                        {
                            Transform firstDetectedObject = controller.fov.visableTagets[0];
                           
                            reactableObject.React(Reactor.ReactorType.Alarm, alarm.reactionPriorityValue, firstDetectedObject, controller.transform);
                        }
                    }
                    else { Debug.Log("IReactable = null on object : " + objectsInAlarmSoundRadius[i].gameObject.name); }

                }
               
                yield return new WaitForSeconds(alarmAgainTIme);
            }
        }
    }

}
