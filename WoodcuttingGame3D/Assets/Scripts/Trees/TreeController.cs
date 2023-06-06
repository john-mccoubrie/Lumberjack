using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void AddExpHandler();
public class TreeController : MonoBehaviour
{
    public static event AddExpHandler AddExperience;

    public float gatheringTimer = 3;
    public bool gathering = false;

    void OnEnable()
    {
        ResourceGatherState.StartGathering += Start_Gathering;
        ResourceGatherState.StopGathering += Stop_Gathering;
    }
    private void OnDisable()
    {
        ResourceGatherState.StartGathering -= Start_Gathering;
        ResourceGatherState.StopGathering -= Stop_Gathering;
    }
    private void Update()
    {
        if(gathering)
        {
            gatheringTimer -= Time.deltaTime;
            if (gatheringTimer <= 0)
            {
                AddExperience();
                gatheringTimer = 3;
            }
        }     
    }
    void Start_Gathering()
    {
        gatheringTimer = 3;
        gathering = true;
    }
    void Stop_Gathering()
    {
        gathering = false;
    }
}
