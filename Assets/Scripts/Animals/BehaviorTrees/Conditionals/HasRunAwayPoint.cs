using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HasRunAwayPoint : Conditional
{
    public SharedTransform playerTransform;
    public SharedVector3 runAwayPoint;

    public float runAwayDistance;



    public override TaskStatus OnUpdate() // The decision to run away or not is not done here. Only the action is
    {        
        Vector3 runawayPosition;
        if(CanGetRunawayPoint(out runawayPosition))
        {
            runAwayPoint.Value = runawayPosition;
            return TaskStatus.Success;
        } else
        {
            return TaskStatus.Failure;
        }
    }


    private bool CanGetRunawayPoint(out Vector3 result)
    {
        Vector3 oppositeDirection = transform.position - playerTransform.Value.position;
        Vector3 runawayPoint = transform.position + oppositeDirection.normalized * runAwayDistance;
       
        NavMeshHit hit;
        if (NavMesh.SamplePosition(runawayPoint, out hit, 1, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        else
        {
            result = transform.position;
            return false;
        }
    }
        

}
