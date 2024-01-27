using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    EnemyStateManager stateManager;
    CapsuleCollider enemyCollider;
    [SerializeField] float disappearingSpeedOnDeath = 0.05f;
    [SerializeField] float timeToDestroyWhenDead = 15f;
    DropItem dropItem;


    [SerializeField] AudioSource hurtSound;
    [SerializeField] AudioSource dieSound;
    [SerializeField] AudioSource roarSound;

    [SerializeField] bool isBoss = false;

    private void Awake()
    {
        stateManager = GetComponent<EnemyStateManager>();
        enemyCollider = GetComponent<CapsuleCollider>();
        dropItem = GetComponent<DropItem>();
    }
    

    void Start()
    {
        health = stateManager.configuration.health;
    }

    
    void Update()
    {
        if(stateManager.isDead)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y - disappearingSpeedOnDeath * Time.deltaTime, transform.position.z);
        }
    }

    public void ReceiveDamage(float damage)
    {
        if(stateManager.isDead) return;

        health -= damage;
        stateManager.animator.SetTrigger("Hit");

        if (!stateManager.playerIsTarget) //if player hurts it, it chases player
        {
            stateManager.playerIsTarget = true;
            stateManager.SetPlayerAsTarget();
            stateManager.GoToNewState(stateManager.ChaseState);
        }

        hurtSound.Play();
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        dropItem.InstantiateDropItems();

        stateManager.navMeshAgent.enabled = false;
        enemyCollider.direction = 2;
        stateManager.isDead = true;
        dieSound.Play();

        roarSound.Stop();

        Invoke(nameof(DisableCollider), 1f);
        stateManager.GoToNewState(stateManager.DieState);
        Destroy(gameObject, timeToDestroyWhenDead);
    }

    private void DisableCollider()
    {
        enemyCollider.enabled = false;
    }

    public bool GetIfDead()
    {
        return stateManager.isDead;
    }

    public void DieByAnimal()
    {
        if(isBoss || stateManager.isDead) return;        
        Die();
    }
        
}
