using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLookRig : MonoBehaviour
{
    [SerializeField] Transform aimTarget;
    [SerializeField] float aimDistanceRigging = 10;
    Transform transformMainCam;
    [SerializeField] float minY = 3;
    [SerializeField] float maxY = 15;

    [SerializeField] List<EnemyHealth> enemiesInLookRange = null;

    Transform targetEnemy;
    [SerializeField] Vector3 direction;

    private void Awake()
    {
        enemiesInLookRange = new List<EnemyHealth>();
        transformMainCam = Camera.main.transform;
    }

    
    void Update()
    {
        if (GameManager.IsPlayerDead) { return; }
        SetPlayerAimRig();
    }

    private void SetPlayerAimRig()
    {    
        if(enemiesInLookRange.Count <= 0)
        {
            AimForwardLook();
        }
        else
        {
            if(GetClosestEnemy() != null)
            {
                AimTowardsClosestEnemy();
            }
        }                
    }

    private void AimTowardsClosestEnemy()
    {
        targetEnemy = GetClosestEnemy().transform;
        direction = targetEnemy.position - transform.position;
        aimTarget.position = targetEnemy.position + direction * aimDistanceRigging;
    }

    private void AimForwardLook()
    {
        Vector3 position = transformMainCam.position + transformMainCam.forward * aimDistanceRigging;
        float clampedY = Mathf.Clamp(position.y, minY, maxY);
        aimTarget.position = new Vector3(position.x, clampedY, position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            if (!enemiesInLookRange.Contains(other.gameObject.GetComponent<EnemyHealth>()))
            {
                enemiesInLookRange.Add(other.gameObject.GetComponent<EnemyHealth>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            if (enemiesInLookRange.Contains(other.gameObject.GetComponent<EnemyHealth>()))
            {
                enemiesInLookRange.Remove(other.gameObject.GetComponent<EnemyHealth>());
            }
        }
    }

    private EnemyHealth GetClosestEnemy()
    {
        float distanceClosestEnemy = Mathf.Infinity;
        EnemyHealth closestEnemy = null;
        foreach(EnemyHealth enemy in enemiesInLookRange)
        {
            if(enemy == null || enemy.GetIfDead()) 
            {
                enemiesInLookRange.Remove(enemy);
                return null; 
            }
            else
            {
                float distanceCurrentEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceCurrentEnemy < distanceClosestEnemy)
                {
                    distanceClosestEnemy = distanceCurrentEnemy;
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }


}
