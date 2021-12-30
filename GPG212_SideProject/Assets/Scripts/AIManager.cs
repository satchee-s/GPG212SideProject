using UnityEngine;

public class AIManager : MonoBehaviour
{
    public Rigidbody rbd;
    public Transform player;
    public float maxRange;
    public State currentState;
    public State IdleBehavior, PursuitBehavior, CaptureBehavior;
    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
        currentState = IdleBehavior;
    }

    public void SetMovement(State state)
    {
        currentState = state;
    }

    private void Update()
    {
        currentState.SetBehavior();
    }
}
