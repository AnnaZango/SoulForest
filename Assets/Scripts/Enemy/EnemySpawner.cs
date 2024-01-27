using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] int numEnemiesToSpawn = 10;
    [SerializeField] float range = 5f;

    [SerializeField] GameObject enemyToSpawn;

    [SerializeField] float timeIntervalToSpawn = 600; //in seconds
    [SerializeField] float timeReductionBetweenIntervals = 60;
    [SerializeField] float minTimeBetweenIntervals = 241;

    [SerializeField] Transform parentEnemiesSpawned;
    [SerializeField] float timePassed;

    [SerializeField] GameObject prefabVFXTransformation;

    SettingsGame settingsGame;

    private void Awake()
    {
        settingsGame = FindObjectOfType<SettingsGame>();
    }

    void Start()
    {
        numEnemiesToSpawn = settingsGame.GetNumEnemiesToSpawn();
        timeIntervalToSpawn = settingsGame.GetTimeBetweenEnemySpawns();

        StartCoroutine(SpawnEnemiesCoroutine());
    }
        

    IEnumerator SpawnEnemiesCoroutine()
    {
        yield return new WaitForSeconds(timeIntervalToSpawn);

        SpawnEnemies(numEnemiesToSpawn);
        if(timeIntervalToSpawn > minTimeBetweenIntervals)
        {
            timeIntervalToSpawn -= timeReductionBetweenIntervals;
        }
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    public void SpawnEnemies(int numberEnemiesToSpawn)
    {
        for (int i = 0; i < numberEnemiesToSpawn; i++)
        {
            Vector3 randomPosition;
            while(GetRandomPosition(out randomPosition) == false)
            {
                GetRandomPosition(out randomPosition);
            }
            GameObject enemy = Instantiate(enemyToSpawn, randomPosition, Quaternion.identity, parentEnemiesSpawned);
        }
    }

    private bool GetRandomPosition(out Vector3 result)
    {
        Vector3 randomPoint = center.position + Random.insideUnitSphere * range;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        else
        {
            result = center.position;
            return false;
        }
    }

    public void InstantiateEnemyAtGivenPosition(GameObject enemyToInstantiate, Vector3 positionToSpawn)
    {
        StartCoroutine(CoroutineEnemyTransformation(enemyToInstantiate, positionToSpawn));
    }

    IEnumerator CoroutineEnemyTransformation(GameObject prefab, Vector3 position)
    {
        Instantiate(prefabVFXTransformation, position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        GameObject enemy = Instantiate(prefab, position, Quaternion.identity, parentEnemiesSpawned);
    }
}
