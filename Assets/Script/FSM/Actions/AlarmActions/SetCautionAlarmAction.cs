using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/SetCautionAlarm")]
public class SetCautionAlarmAction : Action {

    public override void Act(StateController controller)
    {
        if ( !controller.bPrimaryStateActionFinished)
        {
            SetCautionAlarm(controller);
        }
    }

    void SetCautionAlarm(StateController controller)
    {
        Alarm alarm = controller.transform.GetComponent<Alarm>();
        if (alarm != null)
        {
            alarm.alarmPhase = Alarm.AlarmPhase.Caution;
            alarm.ChangeAlarmRadiusColour();
        }
    }
}
