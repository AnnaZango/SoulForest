using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObject : Action
{
    private NavMeshAgent navAgent;
    private Animator animator;

    public float speed = 1f;
    public float stoppingRange = 1;
    public SharedTransform targetObject;
    public GameObject targetGO;

    public override void OnAwake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override void OnStart()
    {
        if(targetObject != null)
        {
            targetGO = targetObject.Value.gameObject;
            if (Utils.isInRange(transform.position, targetObject.Value.position, stoppingRange) == false)
            {
                navAgent.SetDestination(targetObject.Value.position);
                navAgent.speed = speed;
                navAgent.isStopped = false;                 

                if (speed >= 3)
                {
                    animator.SetInteger("state", 5);
                }
                else
                {
                    animator.SetInteger("state", 0);
                }
            }
        }        
    }

    public override TaskStatus OnUpdate()
    {
        if(targetGO == null)
        {
            navAgent.SetDestination(transform.position);
            return TaskStatus.Failure;
        }

        if (Utils.isInRange(transform.position, targetObject.Value.position, stoppingRange))
        {
            navAgent.isStopped = true;
            return TaskStatus.Success;
        }

        if (navAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            navAgent.SetDestination(targetObject.Value.position);
            navAgent.isStopped = false;
        }               

        return TaskStatus.Running;
    }
}
