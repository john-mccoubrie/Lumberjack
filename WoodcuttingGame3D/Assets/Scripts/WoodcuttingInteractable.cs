using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodcuttingInteractable : Interactable
{
    bool loopTest = true;
    public bool checkDis = true;

    public GameObject treeBeingChopped;

    public delegate void ClickAction();
    public static event ClickAction OnClickedTree;

    public delegate void DemolishAction(GameObject treeBeingChopped);
    public static event DemolishAction StartDemolish;

    public delegate void AnimAction();
    public static event AnimAction EndAnim;
    void OnEnable()
    {
        StartCoroutine(Woodcutting());
    }
    IEnumerator Woodcutting()
    {
        while (checkDis)
        {
            yield return new WaitForSeconds(2);
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            while (distance < radius)
            {
                OnClickedTree();
                StartDemolish(treeBeingChopped);
                yield return new WaitForSeconds(1.7f);
                break;
            }
            EndAnim();
        }
    }
    IEnumerator LoopTest()
    {
        while (loopTest)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("test");
        }
    }
}
