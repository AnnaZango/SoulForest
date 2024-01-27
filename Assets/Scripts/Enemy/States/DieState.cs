using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IEnemyBaseState
{
    public void EnterState(EnemyStateManager stateManager)
    {
        stateManager.animator.SetTrigger("Die");
    }

    public void ExitState(EnemyStateManager stateManager)
    {
        
    }

    public void UpdateState(EnemyStateManager stateManager)
    {
        
    }
}
