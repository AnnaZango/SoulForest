using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform elementToLookAt;

    private void Awake()
    {
        elementToLookAt = Camera.main.transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(elementToLookAt);
    }
}
