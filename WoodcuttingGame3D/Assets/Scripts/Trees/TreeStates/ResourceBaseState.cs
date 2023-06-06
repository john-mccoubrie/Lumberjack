using UnityEngine;

public abstract class ResourseBaseState
{
    public abstract void EnterState(ResourceController_FSM resource);
    public abstract void Update(ResourceController_FSM resource);
    public abstract void OnTriggerEnter(ResourceController_FSM resource);
}
