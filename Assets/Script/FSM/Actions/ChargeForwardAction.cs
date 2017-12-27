﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/ChargeForward")]
public class ChargeForwardAction : Action {


    public override void Act(StateController controller)
    {
        if( ! controller.bIsAttacking) { controller.StartCoroutine(ChargeForward(controller)); } 
    }

    IEnumerator ChargeForward(StateController controller)
    {
        controller.bIsAttacking = true;
        controller.myrb.bodyType = RigidbodyType2D.Dynamic;
        controller.myrb.simulated = true;
        controller.myrb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        float chargeTime = 2.0f + Time.time;
        Vector2 forward = controller.stateIndicatorHolder.position - controller.transform.position; 

        while (Time.time < chargeTime)
        {
            controller.myrb.velocity = (forward * controller.entityStats.chargeSpeed) * Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        controller.myrb.bodyType = RigidbodyType2D.Kinematic;
        controller.myrb.simulated = false;
        controller.myrb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
     //   controller.bIsAttacking = false;

    }
}
