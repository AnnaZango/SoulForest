using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour, ICollectible
{
    SweetsStorer sweetsStorer;
    [SerializeField] int numSweetsBucket = 3;

    private void Awake()
    {
        sweetsStorer = FindObjectOfType<SweetsStorer>();
    }


    public void Collect()
    {
        if(sweetsStorer.NumSweets < sweetsStorer.GetNumMaxSweets())
        {
            sweetsStorer.PickupSweets(numSweetsBucket);
            Destroy(gameObject);
        }
    }       

}
