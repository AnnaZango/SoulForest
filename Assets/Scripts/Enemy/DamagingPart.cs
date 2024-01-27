using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingPart : MonoBehaviour
{
    [SerializeField] GameObject damageVFX;
    float damageToInflict;
    Collider colliderDamage;
    AudioSource attackSound;
    EnemyStateManager enemyStateManager;

    private void Awake()
    {
        colliderDamage = GetComponent<Collider>();
        attackSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        colliderDamage.enabled = false;
    }

    public void SetDamageAmount(float damage)
    {
        this.damageToInflict = damage;
    }
    public void SetStateManager(EnemyStateManager stateManager)
    {
        enemyStateManager = stateManager;
    }

    public void EnableCollider()
    {
        attackSound.Play();
        colliderDamage.enabled = true;
    }
    public void DisableCollider()
    {
        colliderDamage.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.IsPlayerDead) { return; }
        if(enemyStateManager.isDead) { return; }

        if (other.gameObject.CompareTag("Player"))
        {
            GameObject vfxDamage = Instantiate(damageVFX, transform.position, Quaternion.identity);
            other.GetComponent<PlayerHealth>().ReceiveDamage(damageToInflict);

        } else if (other.gameObject.CompareTag("Citizen"))
        {
            //hurt NPC
            GameObject vfxDamage = Instantiate(damageVFX, transform.position, Quaternion.identity);
            if(other.GetComponent<CitizenHealth>() != null)
            {
                other.GetComponent<CitizenHealth>().TakeDamage(damageToInflict);
            }
        }
    }


}
