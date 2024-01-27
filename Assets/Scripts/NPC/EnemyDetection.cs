using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] List<EnemyHealth> listEnemiesDetected = null;

    [SerializeField] AudioClip[] soundsScared;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            if (!listEnemiesDetected.Contains(other.gameObject.GetComponent<EnemyHealth>()))
            {
                int randomNum = Random.Range(0, soundsScared.Length);
                audioSource.PlayOneShot(soundsScared[randomNum]);
                listEnemiesDetected.Add(other.gameObject.GetComponent<EnemyHealth>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            if (listEnemiesDetected.Contains(other.gameObject.GetComponent<EnemyHealth>()))
            {
                listEnemiesDetected.Remove(other.gameObject.GetComponent<EnemyHealth>());
            }
        }
    }

    public EnemyHealth GetClosestEnemy()
    {
        float distanceClosestEnemy = Mathf.Infinity;
        EnemyHealth closestEnemy = null;
        foreach (EnemyHealth enemy in listEnemiesDetected)
        {
            if (enemy == null || enemy.GetIfDead())
            {
                listEnemiesDetected.Remove(enemy);
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
