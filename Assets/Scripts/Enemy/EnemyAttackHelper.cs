using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHelper : MonoBehaviour
{
    [SerializeField] DamagingPart[] attackPoints;
    EnemyStateManager stateManager;

    private void Awake()
    {
        stateManager = GetComponent<EnemyStateManager>();
    }

    private void Start()
    {
        foreach (DamagingPart attackPoint in attackPoints)
        {
            attackPoint.SetDamageAmount(stateManager.configuration.damage);
            attackPoint.SetStateManager(stateManager);
        }        
    }

    public void EnableAttackColliderInAnimation()
    {
        foreach(DamagingPart attackPoint in attackPoints)
        {
            attackPoint.EnableCollider();
        }
    }
    public void DisableAttackColliderInAnimation()
    {        
        foreach (DamagingPart attackPoint in attackPoints)
        {
            attackPoint.DisableCollider();
        }
    }
    
}
