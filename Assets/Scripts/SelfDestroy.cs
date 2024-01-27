using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float timeToSelfDestroy = 5f;

    private void Start()
    {
        Destroy(gameObject, timeToSelfDestroy);
    }
}
