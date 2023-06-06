using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    
    public Transform interactionTransform;
    public Transform player;

    bool checkDistance = true;
    bool isFocus = false;
    public bool hasInteracted = false;

    private void Start()
    {
        StartCoroutine(DistanceCheck());
    }

    IEnumerator DistanceCheck()
    {
        while(checkDistance)
        {
            yield return new WaitForSeconds(1);
            if (isFocus)
            {
                float distance = Vector3.Distance(player.position, interactionTransform.position);
                if (distance <= radius && !hasInteracted)
                {
                 Interact();
                 hasInteracted = true; 
                }
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }
    public virtual void Interact()
    {
        //this method is meant to be overriden
    }

    private void OnDrawGizmosSelected()
    {

        if (interactionTransform == null)
            interactionTransform = this.transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
