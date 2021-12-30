using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehavior : State
{
    public float maxForce;
    public float maxSpeed;
    public float frames = 5;
    Vector3 finalPosition = Vector3.zero;
    Vector3 desiredPos;
    Vector3 desiredVelocity;

    public override void SetBehavior()
    {
        base.SetBehavior();
        if (range > manager.maxRange)
        {
            manager.SetMovement(manager.IdleBehavior);
        }
        else if (range <= 1)
        {
            manager.SetMovement(manager.CaptureBehavior);
        }
        else
        {
            //float range = Vector3.Distance(manager.player.position, gameObject.transform.position);
            frames = range / maxSpeed;
            desiredPos = manager.player.transform.position - transform.position;
            desiredPos = desiredPos.normalized * maxSpeed;
            desiredVelocity = desiredPos - (finalPosition * frames);
            desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, maxSpeed);
            desiredVelocity = desiredVelocity / manager.rbd.mass;
            finalPosition = Vector3.ClampMagnitude(finalPosition + desiredVelocity, maxSpeed);
            transform.position += finalPosition * Time.deltaTime;
            transform.forward = finalPosition.normalized;
        }
               
    }
}



