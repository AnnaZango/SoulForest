using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScaredBehavior : Action
{
    public SharedTransform playerTransform;
    private Animator animator;
    public float timeAttackThreshold = 2f;
    public float rotationSpeed = 10f;
    float timePassed;
    RotateObject rotateObject;
    NavMeshAgent navMeshAgent;

    public AudioSource aggressiveSound;


    public override void OnAwake()
    {
        animator = GetComponent<Animator>();
        rotateObject = GetComponent<RotateObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void OnStart()
    {       
        navMeshAgent.isStopped = true;

        animator.SetInteger("state", 2);
        aggressiveSound.Play();

        timePassed = Time.time;
    }

    public override TaskStatus OnUpdate()
    {        
        Vector3 direction = (playerTransform.Value.position - transform.position).normalized;
        direction.y = 0f;

        rotateObject.EnableRotation(direction, rotationSpeed);

        return TaskStatus.Running;
    }
}
