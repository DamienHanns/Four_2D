using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/ChargeForward")]
public class ChargeForwardAction : Action {


    public override void Act(StateController controller)
    {
        if( ! controller.bHasStatedAction) { controller.StartCoroutine(ChargeForward(controller)); } 
    }

    IEnumerator ChargeForward(StateController controller)
    {
        controller.bHasStatedAction = true;         //gets set to false on state change
        controller.myrb.bodyType = RigidbodyType2D.Dynamic;
        controller.myrb.simulated = true;
        controller.myrb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        float chargeTime = 2.0f + Time.time;         

        Vector2 forward = controller.stateIndicatorHolder.position - controller.transform.position; 

        while (Time.time < chargeTime)
        {
            controller.myrb.velocity = (forward * controller.entityStats.attackingStats.chargeSpeed) * Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        controller.myrb.bodyType = RigidbodyType2D.Kinematic;
        controller.myrb.simulated = false;
        controller.myrb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        controller.myrb.velocity = Vector3.zero;
        controller.bPrimaryStateActionFinished = true;
    }


}
