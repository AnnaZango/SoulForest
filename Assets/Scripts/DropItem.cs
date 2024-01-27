using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject[] dropItemsPrefab;

    [SerializeField] float randomRangeInstances = 3;
    [SerializeField] float dropProbability = 0.3f;
    [SerializeField] float timeToDrop = 2;
    [SerializeField] float dropHeight = 1.5f;
    [SerializeField] AudioSource dropSound;
    [SerializeField] bool randomize = false;

    SettingsGame settinggGame;

    private void Awake()
    {
        settinggGame = FindObjectOfType<SettingsGame>();
    }

    private void Start()
    {
        dropProbability = settinggGame.GetProbabilityItemDrop();
    }

    public void InstantiateDropItems()
    {
        if(dropItemsPrefab.Length <= 0) { return; }
        StartCoroutine(IntstantiateCoroutine());
    }

    IEnumerator IntstantiateCoroutine()
    {
        yield return new WaitForSeconds(timeToDrop);

        foreach (var dropItem in dropItemsPrefab)
        {
            if (randomize)
            {
                float randomNum = Random.Range(0, 1.0f);
                if(randomNum <= dropProbability)
                {
                    Vector3 randomPosition = GetRandomPositionWithinRange();
                    Instantiate(dropItem, randomPosition, Quaternion.identity);
                    dropSound.Play();
                }
            }
            else
            {
                Vector3 randomPosition = GetRandomPositionWithinRange();
                Instantiate(dropItem, randomPosition, Quaternion.identity);
                dropSound.Play();
            }

        }        
    }

    private Vector3 GetRandomPositionWithinRange()
    {
        Vector3 randomPosition = new Vector3(
            transform.position.x + Random.Range(-randomRangeInstances, randomRangeInstances),
            transform.position.y + dropHeight, //slightly higher to make it more visible
            transform.position.z + Random.Range(-randomRangeInstances, randomRangeInstances)
            );
        return randomPosition;
    }

    private void RandomizePrefabsToDrop()
    {

    }
}
