using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizenNPC : MonoBehaviour
{
    [SerializeField] float roamingRange = 4;
    [SerializeField] float speedRoaming = 1.5f;
    [SerializeField] float speedFleeing = 2.5f;
    [SerializeField] float runawayDistance = 3;

    NavMeshAgent navMeshAgent;

    [SerializeField] EnemyDetection enemyDetection;
    CitizenHealth health;
    Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<CitizenHealth>();
        
    }    

    void Start()
    {
        navMeshAgent.speed = speedRoaming;
    }
        

    void Update()
    {
        if(health.IsDead()) return;

        if(enemyDetection.GetClosestEnemy() == null)
        {
            animator.SetBool("RunAway", false);
            Roam();
        }
        else
        {
            RunAway(enemyDetection.GetClosestEnemy().transform.position);
            animator.SetBool("RunAway", true);
        }        

    }

    private void Roam()
    {
        navMeshAgent.speed = speedRoaming;
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) //arrived at destination
        {
            Vector3 randomPoint;
            if (CanGetRandomPoint(out randomPoint))
            {
                Debug.DrawRay(randomPoint, Vector3.up, Color.green, 1);
                navMeshAgent.SetDestination(randomPoint);
            }
        }
    }

    private void RunAway(Vector3 enemyPosition)
    {
        float distanceToEnemy = Vector3.Distance(transform.position, enemyPosition);
        if(distanceToEnemy < runawayDistance)
        {
            navMeshAgent.speed = speedFleeing;
            Vector3 oppositeDirection = transform.position - enemyPosition;
            Vector3 newPosition = transform.position + oppositeDirection;

            SampleNavmeshPosition(newPosition);
        }
    }

    private void SampleNavmeshPosition(Vector3 position)
    {
        if (NavMesh.SamplePosition(position, out _, 1, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(position);
        }
    }
    

    private bool CanGetRandomPoint(out Vector3 result)
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * roamingRange;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}
