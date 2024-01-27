using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyBaseState
{
    public void EnterState(EnemyStateManager stateManager)
    {
        
    }

    public void UpdateState(EnemyStateManager stateManager)
    {
        if (!stateManager.navMeshAgent.enabled) { return; }

        // always rotate towards target
        Quaternion rotationTarget = Quaternion.LookRotation(stateManager.currentTargetTransform.position - stateManager.transform.position);

        stateManager.transform.rotation = Quaternion.RotateTowards(stateManager.transform.rotation,
            rotationTarget, stateManager.configuration.rotationSpeedTowardsPlayer * Time.deltaTime);

        float distanceToPlayer = stateManager.GetDistanceToTarget();
             

        if (distanceToPlayer > stateManager.configuration.attackRange)
        {            
            if (stateManager.playerIsTarget)
            {
                stateManager.GoToNewState(stateManager.ChaseState);
            }
            else
            {
                if (stateManager.GetIfNPCtarget())
                {
                    stateManager.GoToNewState(stateManager.ChaseState);
                }
                else //if it is null, back to roam
                {
                    stateManager.GoToNewState(stateManager.RoamState);
                }
            }            
        }
        else
        {
            stateManager.navMeshAgent.isStopped = true;
            stateManager.animator.SetBool("AttackHit", true);
        }
    }

    public void ExitState(EnemyStateManager stateManager)
    {
        if(stateManager.navMeshAgent == null) { return; }
        stateManager.navMeshAgent.isStopped = false;
        stateManager.animator.SetBool("AttackHit", false);
    }

    
}
