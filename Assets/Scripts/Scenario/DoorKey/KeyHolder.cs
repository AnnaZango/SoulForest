using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList = new List<Key.KeyType>();

    KeyUIDisplay keyUI;

    [SerializeField] AudioSource keySound;
    [SerializeField] AudioSource openDoor;

    private void Awake()
    {        
        keyUI = FindObjectOfType<KeyUIDisplay>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Key key = other.gameObject.GetComponent<Key>();

        if (key != null)
        {
            AddKey(key.GetKeyType());
            keySound.Play();
            Destroy(key.gameObject);
            keyUI.UpdateKeysUI(key.GetKeyType(), true);
        }

        KeyDoor keyDoor = other.gameObject.GetComponent<KeyDoor>();
        
        if(keyDoor != null)
        {
            if (keyDoor.IsDoorOpen()) { return; } //already open

            if (ContainsKey(keyDoor.GetKeyType()))
            {
                //open door and remove key from list
                keyDoor.OpenDoor();
                RemoveKey(keyDoor.GetKeyType());
                keyUI.UpdateKeysUI(keyDoor.GetKeyType(), false);
                openDoor.Play();   
            }
        }
    }



    private bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void AddKey(Key.KeyType keyToAdd)
    {
        keyList.Add(keyToAdd);
    }
    private void RemoveKey(Key.KeyType keyToRemove)
    {
        keyList.Remove(keyToRemove);
    }
}
