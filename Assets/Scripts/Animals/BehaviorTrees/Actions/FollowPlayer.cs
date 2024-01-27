using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : Action
{
    private NavMeshAgent navAgent;
    private Animator animator;

    public float speed = 1f;
    public float stoppingRange = 1;
    public SharedTransform playerTarget;

    [SerializeField] AudioSource inquirySound;
    public override void OnAwake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override void OnStart()
    {
        if (Utils.isInRange(transform.position, playerTarget.Value.position, stoppingRange) == false)
        {
            navAgent.SetDestination(playerTarget.Value.position);
            navAgent.speed = speed;
            navAgent.isStopped = false;

            inquirySound.Play();

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

    public override TaskStatus OnUpdate()
    {
        if (Utils.isInRange(transform.position, playerTarget.Value.position, stoppingRange))
        {
            navAgent.isStopped = true;
            animator.SetInteger("state", 4);

            return TaskStatus.Success;
        }

        if (navAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            navAgent.SetDestination(playerTarget.Value.position);
            navAgent.isStopped = false;
        }

        return TaskStatus.Running;
    }
}
