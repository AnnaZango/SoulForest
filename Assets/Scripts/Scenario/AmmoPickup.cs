using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour, ICollectible
{
    [SerializeField] int indexWeapon;
    WeaponsController weaponsController;
    Collider myCollider;
    [SerializeField] AudioSource soundPickup;

    private void Awake()
    {
        weaponsController = FindObjectOfType<WeaponsController>();
        myCollider = GetComponent<Collider>();
    }

    public void Collect()
    {
        if (weaponsController.GetIfMaxAmmo(indexWeapon)) { return; }
        weaponsController.RefillAmmo(indexWeapon);
        soundPickup.Play();
        DestroyDelayed();
    }

    private void DestroyDelayed()
    {
        if (myCollider != null)
        {
            myCollider.enabled = false;
        }
        transform.GetChild(0).gameObject.SetActive(false); // render
        Destroy(gameObject, 1);
    }
}
