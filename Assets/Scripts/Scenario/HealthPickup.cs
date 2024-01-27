using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, ICollectible
{
    [SerializeField] float amount = 5;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void Collect()
    {
        if (playerHealth.GetIfMaxHealth()) { return; }

        playerHealth.ReceiveHealth(amount);
        Destroy(gameObject);
    }

    
}
