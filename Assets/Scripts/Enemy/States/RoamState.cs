using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamState : IEnemyBaseState
{    
   
    public void EnterState(EnemyStateManager stateManager)
    {
        stateManager.navMeshAgent.isStopped = false;
        stateManager.navMeshAgent.SetDestination(stateManager.transform.position);
        stateManager.navMeshAgent.speed = stateManager.configuration.roamingSpeed;
        stateManager.animator.SetBool("Chase", false);
    }

    public void UpdateState(EnemyStateManager stateManager)
    {
        if (!stateManager.navMeshAgent.enabled) { return; }

        float distanceToPlayer = stateManager.GetDistanceToTarget();

        if (distanceToPlayer < stateManager.configuration.detectionDistance) 
        {
            stateManager.GoToNewState(stateManager.ChaseState);        
        }
        else
        {
            //roam
            if(stateManager.navMeshAgent.remainingDistance <= stateManager.navMeshAgent.stoppingDistance) //arrived at destination
            {
                Vector3 randomPoint;
                if(CanGetRandomPoint(stateManager, out randomPoint))
                {
                    Debug.DrawRay(randomPoint, Vector3.up, Color.green, 1);
                    stateManager.navMeshAgent.SetDestination(randomPoint);
                }
                
            }
        }

    }

    public void ExitState(EnemyStateManager stateManager)
    {
        
    }

    private bool CanGetRandomPoint(EnemyStateManager stateManager, out Vector3 result)
    {
        Vector3 randomPoint = stateManager.transform.position + Random.insideUnitSphere * stateManager.configuration.roamingRange;

        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;    
    }


    
}
