using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New configuration", menuName = "Enemy configuration")]
public class EnemyConfiguration : ScriptableObject
{
    public float detectionDistance = 20;
    public float stopChasingDistance = 50;
    public float attackRange = 1.5f;
    public float roamingRange = 5;
    public float rotationSpeedTowardsPlayer = 0f; //no rotation

    public float roamingSpeed = 1.5f;
    public float chasingSpeed = 4f;
    public float health = 10;
    public float damage = 2;

}
