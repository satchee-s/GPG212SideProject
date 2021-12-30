using UnityEngine;

public class IdleBehavior : State
{
    public override void SetBehavior()
    {
        base.SetBehavior();
        if (range <= manager.maxRange)
        {
            manager.SetMovement(manager.PursuitBehavior);
        }
        else
        {
            manager.rbd.velocity = Vector3.zero;
        }
    }
}
