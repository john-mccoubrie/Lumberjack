using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Camera cam;
    public PlayerMotor motor;
    Animator anim;
    Interactable focus;
    public GameObject questWindow;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //might need to place this somewhere else (this was getting fucked up under pointer calls)
        if (Input.GetButtonDown("Investment"))
        {
            questWindow.SetActive(!questWindow.activeSelf);
        }
        //ends here
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //movement and focus on objects when they're clicked on
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out hit, 100))
            {
                agent.destination = hit.point;
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }else
                {
                    RemoveFocus();
                }
                
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        motor.FollowTarget(newFocus);
        if(focus != null)
        {
            focus.OnFocused(transform);
        }
    }
    void RemoveFocus()
    {
        focus = null;
        motor.StopFollowingTarget();
    }
}
