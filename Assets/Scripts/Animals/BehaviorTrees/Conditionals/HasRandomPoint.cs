using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HasRandomPoint : Conditional
{
    public float range;
    public SharedVector3 randomPosition;

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
        Vector3 randomPos = SetRandomPoint();

        if (randomPos != transform.position)
        {
            randomPosition.Value = randomPos;
            return TaskStatus.Success;
        }
        else { return TaskStatus.Failure; }
    }

    private Vector3 SetRandomPoint()
    {
        Vector3 randomPosition;
        if(CanGetRandomPoint(out randomPosition))
        {
            return randomPosition;
        }
        else
        {
            return transform.position;
        }
    }

    private bool CanGetRandomPoint(out Vector3 result)
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * range;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas))
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
