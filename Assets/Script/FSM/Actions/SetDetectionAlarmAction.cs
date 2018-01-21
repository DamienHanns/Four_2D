using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/SetDetectionAlarm")]
public class SetDetectionAlarmAction : Action {

    public override void Act(StateController controller)
    {
        if ( !controller.bPrimaryStateActionFinished)
        {
            SetDetectionAlarm(controller);
        }
    }

    void SetDetectionAlarm(StateController controller)
    {
        Alarm alarm = controller.transform.GetComponent<Alarm>();
        if (alarm != null)
        {
            alarm.alarmPhase = Alarm.AlarmPhase.Detection;
            alarm.ChangeAlarmRadiusColour();
        }
    }
}
