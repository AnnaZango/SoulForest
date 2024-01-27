using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsObject : Action
{
    public SharedTransform targetObject;
    public float rotationSpeed = 1f;
    RotateObject rotateObject;
    GameObject targetGO;
    Animator animator;

    public override void OnAwake()
    {
        animator = GetComponent<Animator>();
        rotateObject = GetComponent<RotateObject>();
    }

    public override void OnStart()
    {
        if(targetObject != null)
        {
            animator.SetInteger("state", 4);
            targetGO = targetObject.Value.gameObject;
        }
    }

    public override TaskStatus OnUpdate()
    {
        if(targetGO == null)
        {
            rotateObject.DisableRotation();
            return TaskStatus.Failure;
        }

        Vector3 direction = (targetObject.Value.position - transform.position).normalized;
        direction.y = 0f;
        
        rotateObject.EnableRotation(direction, rotationSpeed);

        if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(direction)) < 1)
        {
            rotateObject.DisableRotation();            
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }

    public override void OnConditionalAbort()
    {
        rotateObject.DisableRotation();
    }


}
