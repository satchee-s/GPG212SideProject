using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureBehavior : State
{
    public override void SetBehavior()
    {
        base.SetBehavior();
        if (range > manager.maxRange)
        {
            manager.SetMovement(manager.IdleBehavior);
        }
        else if (range <= 1)
        {
            manager.player.position = new Vector3(1f, 1f, 11f);

        }
        else
            manager.SetMovement(manager.PursuitBehavior);

    }
}
