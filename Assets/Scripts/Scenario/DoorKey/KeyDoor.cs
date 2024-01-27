using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] Key.KeyType keyType; //select in inspector

    Animator animator;
    bool isOpen = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {        
        animator.SetBool("open", true);
        isOpen = true;
    }

    public bool IsDoorOpen()
    {
        return isOpen;
    }

}
