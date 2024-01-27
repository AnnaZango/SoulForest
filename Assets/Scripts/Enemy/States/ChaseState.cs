using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IEnemyBaseState
{
    public void EnterState(EnemyStateManager stateManager)
    {
        stateManager.navMeshAgent.speed = stateManager.configuration.chasingSpeed;
        stateManager.animator.SetBool("Chase", true);
    }

    public void UpdateState(EnemyStateManager stateManager)
    {
        if (!stateManager.navMeshAgent.enabled) { return; }

        float distanceToTarget = stateManager.GetDistanceToTarget();

        if (stateManager.playerIsTarget)
        {
            ChasePlayer(stateManager, distanceToTarget);
        }
        else
        {
            ChaseNPC(stateManager, distanceToTarget);
        }

    }

    private static void ChaseNPC(EnemyStateManager stateManager, float distanceToTarget)
    {
        if (distanceToTarget < stateManager.configuration.attackRange) //too close
        {
            stateManager.navMeshAgent.isStopped = true;
            stateManager.GoToNewState(stateManager.AttackState);
        }
        else if (distanceToTarget > stateManager.configuration.detectionDistance) //stop following NPC when outside detection distance
        {
            stateManager.navMeshAgent.isStopped = true;
            if (stateManager.GetIfPlayerIsTarget())
            {
                stateManager.playerIsTarget = false;
            }
            stateManager.GoToNewState(stateManager.RoamState);
        }
        else
        {
            stateManager.navMeshAgent.isStopped = false;
            stateManager.navMeshAgent.SetDestination(stateManager.currentTargetTransform.position);
        }
    }

    private static void ChasePlayer(EnemyStateManager stateManager, float distanceToTarget)
    {
        if (distanceToTarget < stateManager.configuration.attackRange) //too close
        {
            stateManager.navMeshAgent.isStopped = true;
            stateManager.GoToNewState(stateManager.AttackState);
        }
        else if (distanceToTarget > stateManager.configuration.stopChasingDistance) // chase player far longer than detection distance
        {
            stateManager.navMeshAgent.isStopped = true;
            if (stateManager.GetIfPlayerIsTarget())
            {
                stateManager.playerIsTarget = false;
            }
            stateManager.GoToNewState(stateManager.RoamState);
        }
        else
        {
            stateManager.navMeshAgent.isStopped = false;
            stateManager.navMeshAgent.SetDestination(stateManager.currentTargetTransform.position);
        }
    }

    public void ExitState(EnemyStateManager stateManager)
    {
        
    }

    
}
