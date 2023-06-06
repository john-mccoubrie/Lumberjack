using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDemolisher : MonoBehaviour
{
    public float chopDownTime;
    public bool chopDownTimeStarted = false;
    public bool rangeSet = false;


    public float respawnTime;
    public bool respawnStarted = false;
    public bool rangeSetRespawn = false;
    public GameObject tree;

    private void OnEnable()
    {
        WoodcuttingInteractable.OnClickedTree += StartChopDown;
        WoodcuttingInteractable.StartDemolish += SelectTreeToDemolish;
    }
    private void OnDisable()
    {
        WoodcuttingInteractable.OnClickedTree -= StartChopDown;
        WoodcuttingInteractable.StartDemolish -= SelectTreeToDemolish;
    }
    void Update()
    {
        if(chopDownTimeStarted) //and if the player is chopping the tree still
        { 
            chopDownTime -= Time.deltaTime;
            if (chopDownTime <= 0.0f)
            {
                SelectTreeToDemolish(tree);
                DemolishTree();
                chopDownTimeStarted = false;
            }
        }


        if (respawnStarted)
        {
            respawnTime -= Time.deltaTime;
            if (respawnTime <= 0.0f)
            {
                tree.SetActive(true);
                Reset();
            }
        }
    }
    void StartChopDown()
    {
        chopDownTimeStarted = true;
        if(!rangeSet)
        {
            chopDownTime = Random.Range(10f, 60f);
            rangeSet = true;
        }
    }
    void DemolishTree()
    {
        StartRespawn();
        tree.SetActive(false);
    }

    void StartRespawn()
    {
        respawnStarted = true;
        if (!rangeSetRespawn)
        {
            respawnTime = Random.Range(10f, 15f);
            rangeSetRespawn = true;
        }
    }
    public void Reset()
    {
        chopDownTime = 0;
        chopDownTimeStarted = false;
        rangeSet = false;

        respawnTime = 0;
        respawnStarted = false;
        rangeSetRespawn = false;

       //StartChopDown(); //this keeps the respawn/spawn loop going -- will need to check in the player is still cutting
    }
    void SelectTreeToDemolish(GameObject treeToDemolish)
    {
        tree = treeToDemolish;
    }
}
