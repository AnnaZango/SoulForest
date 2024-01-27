using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //We need to perform the rotation here because behavior tree ticks happen every half a second, and movement wouldnt be smooth
    public bool enableRotation = false;
    public float rotationSpeed = 15;
    private Vector3 targetDirection;

    
    void Update()
    {
        if (enableRotation)
        {
            if(Vector3.Distance(transform.position, targetDirection) < Mathf.Epsilon ) { return; }
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), rotationSpeed * Time.deltaTime);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            transform.rotation = targetRotation;
        }
    }

    public void EnableRotation(Vector3 direction, float speed)
    {       
        targetDirection = direction;
        rotationSpeed = speed;

        if (!enableRotation) { enableRotation = true; }        
    }

    public void DisableRotation()
    {
        enableRotation = false;
        targetDirection = transform.position;
    }
}
