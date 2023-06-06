using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AnimAction();
public delegate void SkillGatheringHandler();

public class ResourceGatherState : ResourseBaseState
{
    public static event SkillGatheringHandler StartGathering;
    public static event SkillGatheringHandler StopGathering;

    public static event AnimAction StartWoodcuttingAnimation;
    public static event AnimAction StopWoodcuttingAnimation;
    public override void EnterState(ResourceController_FSM resource)
    {
        Debug.Log("Gather State");
        resource.cutTimer = 30;
        StartGathering();
        StartWoodcuttingAnimation();
    }

    public override void OnTriggerEnter(ResourceController_FSM resource)
    {
        
    }

    public override void Update(ResourceController_FSM resource)
    {
        #region Cutting Logs
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Tree"))
                {
                    //if you click another tree -- it will become the new focused tree
                    if(hit.transform.name != resource.focusedTree.name)
                    {
                        resource.focusedTree = hit.transform.gameObject;
                        resource.cutTimer = 10;
                    }
                }
                else
                {
                    //if you click a non-tree -- the player will go back to the idle state
                    StopWoodcuttingAnimation();
                    StopGathering();
                    resource.TransitionToState(resource.IdleState);
                }

            }
        }
        //start timer for the tree cut down
        resource.cutTimer -= Time.deltaTime;
        if(resource.cutTimer <= 0)
        {
            StopWoodcuttingAnimation();
            StopGathering();
            resource.TransitionToState(resource.RespawnState);
        }
        #endregion
    }
}
