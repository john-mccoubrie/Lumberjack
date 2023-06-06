using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpotController : MonoBehaviour
{

    public float gatheringTimer = 3;
    public bool gathering = false;

    private void OnEnable()
    {
        ResourceGatherState.StartGathering += Start_Gathering;
        ResourceGatherState.StopGathering += Stop_Gathering;
    }

    private void OnDisable()
    {
        ResourceGatherState.StartGathering -= Start_Gathering;
        ResourceGatherState.StopGathering -= Stop_Gathering;
    }


    // Update is called once per frame
    void Update()
    {
        if (gathering)
        {
            gatheringTimer -= Time.deltaTime;
            if (gatheringTimer <= 0)
            {
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
