using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/FaceTarget")]
public class FaceTargetAction : Action {

    public override void Act(StateController controller)
    {
        Vector3 dirToTarget = controller.priorityOOI.position - controller.transform.position;

        float angle = (Mathf.Atan2(dirToTarget.y, dirToTarget.x) * Mathf.Rad2Deg) - 90.0f;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, q, Time.deltaTime * 5.0f);
    }

}
