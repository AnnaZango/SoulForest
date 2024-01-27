using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFront : MonoBehaviour
{
    BoxCollider colliderFront;
    [SerializeField] GameObject explosionPrefab;

    private void Awake()
    {
        colliderFront = GetComponent<BoxCollider>();
    }
    


    public void EnableCollider()
    {
        colliderFront.enabled = true;
    }

    public void DisableCollider()
    {
        colliderFront.enabled = false;
    }

    public bool GetIfColliderEnabled()
    {
        return colliderFront.enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyHealth>().DieByAnimal();
        }
    }
}
