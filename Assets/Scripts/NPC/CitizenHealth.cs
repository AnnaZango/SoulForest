using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizenHealth : MonoBehaviour
{
    EnemySpawner spawner;
    [SerializeField] float healthPoints = 3;
    [SerializeField] GameObject prefabEnemy;
    bool isDead = false;
    CitizenNPC npc;
    Collider colliderNPC;
    NavMeshAgent navMesh;
    Animator animator;

    [SerializeField] AudioClip[] soundsDead;
    AudioSource audioSource;

    private void Awake()
    {
        spawner = GameObject.FindObjectOfType<EnemySpawner>();
        colliderNPC = GetComponent<Collider>();
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        isDead = false;
    }


    public void TakeDamage(float damage)
    {
        if (isDead) { return; }

        healthPoints -= damage;
        if(healthPoints <= 0)
        {          
            Die();
        }
    }

    private void Die()
    {
        healthPoints = 0;

        animator.SetTrigger("Transform");

        int randomSoundIndex = UnityEngine.Random.Range(0, soundsDead.Length - 1);
        audioSource.PlayOneShot(soundsDead[randomSoundIndex]);

        isDead = true;
        colliderNPC.enabled = false;
        navMesh.isStopped = true;

        Invoke(nameof(InstantiateEnemyAndDestroy), 1.5f);        
    }

    private void InstantiateEnemyAndDestroy()
    {
        spawner.InstantiateEnemyAtGivenPosition(prefabEnemy, transform.position);
        Destroy(gameObject, 0.4f);
    }

    public bool IsDead()
    {
        return isDead;
    }
}
