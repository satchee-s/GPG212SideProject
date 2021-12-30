using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected AIManager manager;
    protected float range;

    public virtual void SetBehavior()
    {
        range = Vector3.Distance(manager.player.position, transform.position);
    }
    private void Start()
    {
        manager = GameObject.Find("Enemy").GetComponent < AIManager>();
    }
}
