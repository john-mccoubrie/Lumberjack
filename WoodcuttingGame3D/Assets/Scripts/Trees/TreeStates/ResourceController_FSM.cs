using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController_FSM : MonoBehaviour
{
    #region Resource Variables

    public GameObject focusedTree;
    public GameObject treeToRespawn;
    private Rigidbody rbody;

    public float radius;
    public float cutTimer;
    public float respawnTimer;
    public bool respawnTimerStarted;
    public bool treeClicked = false;

    public Item item;

    #endregion
    
    private ResourseBaseState currentState;
    public ResourseBaseState CurrentState
    {
        get { return currentState; }
    }
    public Rigidbody RigidBody { get { return rbody; } }

    public readonly ResourceIdleState IdleState = new ResourceIdleState();
    public readonly ResourceGatherState GatherState = new ResourceGatherState();
    public readonly ResourceDepletedState DepletedState = new ResourceDepletedState();
    public readonly ResourceRespawnState RespawnState = new ResourceRespawnState();
    
    private void Start()
    {
        TransitionToState(IdleState);
        radius = 3f;
    }
    void Update()
    {
        currentState.Update(this);


        if(respawnTimerStarted)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer <= 0)
            {
                treeToRespawn.SetActive(true);
                respawnTimerStarted = false;
            }
        }
    }
    public void TransitionToState(ResourseBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this); //might need to take a look at this again in the video
    }
}
