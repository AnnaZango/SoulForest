using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatGround : Action
{
    private Animator animator;
    NavMeshAgent agent;

    public override void OnAwake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public override void OnStart()
    {
        agent.isStopped = true;
        animator.SetInteger("state", 1);
    }
}
