using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObjectClose : Conditional
{
    public SharedFloat range;
    public string objectTag;
    public SharedTransform closestObject;
    public SharedGameObject elementGameObject;
    RotateObject rotateObject;

    public override void OnAwake()
    {
        rotateObject = GetComponent<RotateObject>();
    }

    public override void OnStart()
    {
        rotateObject.DisableRotation();
    }
    public override TaskStatus OnUpdate()
    {
        Transform closestObjectFound = Utils.FindClosestObject(transform, range.Value, objectTag);
        if(closestObjectFound != null)
        {
            closestObject.Value = closestObjectFound;
            elementGameObject = closestObjectFound.gameObject;
            return TaskStatus.Success;
        } else { return TaskStatus.Failure; }
    }
}
