using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBaseState 
{
    public void EnterState(EnemyStateManager stateManager);

    public void UpdateState(EnemyStateManager stateManager);

    public void ExitState(EnemyStateManager stateManager);
}
