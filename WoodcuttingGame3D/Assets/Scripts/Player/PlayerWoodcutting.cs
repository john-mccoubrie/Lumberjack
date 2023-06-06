using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWoodcutting : MonoBehaviour
{

    Animator anim;
    public delegate void DemolishAction();
    public static event DemolishAction ResetTreeDemolish;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnEnable()
    {
        //WoodcuttingInteractable.OnClickedTree += CutLogs;
        //WoodcuttingInteractable.EndAnim += EndWoodcuttingAnim;
        ResourceGatherState.StartWoodcuttingAnimation += BeginWoodcuttingAnim;
        ResourceGatherState.StopWoodcuttingAnimation += EndWoodcuttingAnim;
    }

    private void OnDisable()
    {
        //WoodcuttingInteractable.OnClickedTree -= CutLogs;
        //WoodcuttingInteractable.EndAnim -= EndWoodcuttingAnim;
        ResourceGatherState.StartWoodcuttingAnimation -= BeginWoodcuttingAnim;
        ResourceGatherState.StopWoodcuttingAnimation -= EndWoodcuttingAnim;
    }

    void BeginWoodcuttingAnim()
    {       
        anim.SetBool("isCutting", true);         
    }

    void EndWoodcuttingAnim()
    {
        anim.SetBool("isCutting", false);
    }
}
