using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodElement : MonoBehaviour
{
    public float trustValueIncrease = 0.2f;

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
