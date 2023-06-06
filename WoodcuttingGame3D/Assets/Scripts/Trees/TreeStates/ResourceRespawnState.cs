using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void RespawnHandler();
public class ResourceRespawnState : ResourseBaseState
{
    public override void EnterState(ResourceController_FSM resource)
    {
        Debug.Log("Respawn State");
        resource.focusedTree.SetActive(false);
        resource.respawnTimer = 10;    
    }

    public override void OnTriggerEnter(ResourceController_FSM resource)
    {
       
    }

    public override void Update(ResourceController_FSM resource)
    {
        //if the respawnTimer is faster than the cutdown timer the tree that was cut down will not be respawned
        resource.respawnTimerStarted = true;
        resource.treeToRespawn = resource.focusedTree;
        resource.TransitionToState(resource.IdleState);
    }
}
