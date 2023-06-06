using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIdleState : ResourseBaseState
{
    public override void EnterState(ResourceController_FSM resource)
    {
        Debug.Log("Idle State");
        resource.treeClicked = false;
    }

    public override void OnTriggerEnter(ResourceController_FSM resource)
    {
        
    }

    public override void Update(ResourceController_FSM resource)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Tree"))
                {
                    resource.treeClicked = true;
                    resource.focusedTree = hit.transform.gameObject;             
                }
            }
        }
        float distance = Vector3.Distance(resource.gameObject.transform.position, resource.focusedTree.transform.position);
        if (distance < resource.radius)
        {
            if (resource.treeClicked)
                resource.TransitionToState(resource.GatherState);
        }
    }
}
