using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSetter : MonoBehaviour
{
    [SerializeField] Transform targetNPC;

    private void OnTriggerEnter(Collider other)
    {
        if(targetNPC != null) { return; } //they are not very smart, if they already have a target they follow that one...

        if (other.gameObject.CompareTag("Citizen"))
        {
            targetNPC = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Citizen"))
        {
            targetNPC = null;
        }
    }

    public Transform GetTargetNPC()
    {
        return targetNPC;
    }
    
    public bool GetIfTargetNPC()
    {
        return (targetNPC != null);
    }

}
