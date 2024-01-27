using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : Action
{
    private NavMeshAgent navAgent;
    private Animator animator;

    public float speed = 1f;
    public float stoppingRange = 1;
    public SharedVector3 targetPosition;

    public override void OnAwake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override void OnStart()
    {
        if (Utils.isInRange(transform.position, targetPosition.Value, stoppingRange) == false)
        {
            navAgent.SetDestination(targetPosition.Value);
            navAgent.speed = speed;
            navAgent.isStopped = false;
            if(speed >= 3)
            {
                animator.SetInteger("state", 5);
            }
            else
            {
                animator.SetInteger("state", 0);
            }
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (targetPosition == null)
        {
            return TaskStatus.Failure;
        }

        if (navAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            navAgent.SetDestination(targetPosition.Value);
            navAgent.isStopped = false;
        }

        if (Utils.isInRange(transform.position, targetPosition.Value, stoppingRange))
        {
            navAgent.isStopped = true;
            //animator.SetBool("walk", false);
            //animator.SetBool("run", false);
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }
}
