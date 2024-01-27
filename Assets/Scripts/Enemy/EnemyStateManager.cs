using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    //This is the context. It gives context to the states so they know what to do

    public EnemyConfiguration configuration;

    [HideInInspector] public RoamState RoamState = new RoamState();
    [HideInInspector] public ChaseState ChaseState = new ChaseState();
    [HideInInspector] public AttackState AttackState = new AttackState();
    [HideInInspector] public DieState DieState = new DieState();

    [HideInInspector] public Animator animator;
    [HideInInspector] public Transform playerTransform;
    [HideInInspector] public Transform currentTargetTransform;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] private EnemyTargetSetter targetSetter;
    [HideInInspector] public bool isDead;

    private IEnemyBaseState currentState = null;
    public bool playerIsTarget = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        targetSetter = GetComponentInChildren<EnemyTargetSetter>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {        
        isDead = false;
        currentState = RoamState;
        currentState.EnterState(this);
    }

    
    void Update()
    {
        SetTarget();
        currentState.UpdateState(this);
    }

    private void SetTarget()
    {
        if (playerIsTarget) { return; }

        if(GetDistanceToPlayer() < configuration.detectionDistance)
        {
            currentTargetTransform = playerTransform;
            playerIsTarget = true;
        } else if(targetSetter.GetIfTargetNPC())
        {           
            currentTargetTransform = targetSetter.GetTargetNPC().transform;
        }
        else
        {
            currentTargetTransform = playerTransform;
        }
    }

    public void SetPlayerAsTarget()
    {
        currentTargetTransform = playerTransform;
    }

    public bool GetIfPlayerIsTarget()
    {
        return playerIsTarget;
    }

    public bool GetIfNPCtarget()
    {
        return targetSetter.GetTargetNPC() != null;
    }

    private float GetDistanceToPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        return distance;
    }

    public IEnemyBaseState GetCurrentState()
    {
        return currentState;
    }

    public void GoToNewState(IEnemyBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    public float GetDistanceToTarget() //perhaps better optimization if only calculates it when player enters a detection collider?
    {
        float distance = Vector3.Distance(transform.position, currentTargetTransform.position);        
        return distance;
    }

}
