using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SweetsStorer : MonoBehaviour
{
    [SerializeField] int maxNumSweets = 10;
    [SerializeField] int numSweets = 0;
    [SerializeField] GameObject[] sweetPrefabs;
    [SerializeField] Transform dropPoint;
    [SerializeField] Slider sliderSweets;

    [SerializeField] AudioSource dropSweetSound;
    [SerializeField] AudioSource noSweetsSound;
    [SerializeField] AudioSource pickupSweetSound;

    public int NumSweets
    {
        get => numSweets;
        set 
        { 
            numSweets = Mathf.Clamp(value, 0, maxNumSweets); 
        }
    }

    private void Start()
    {
        UpdateSliderSweets();
    }

    private void UpdateSliderSweets()
    {
        float relativeValue = (float)NumSweets / (float)maxNumSweets;
        sliderSweets.value = relativeValue;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            DropSweets();
        }
    }

    public void PickupSweets(int numSweetsPickup)
    {
        NumSweets += numSweetsPickup;
        UpdateSliderSweets();
        pickupSweetSound.Play();
    }

    public int GetNumMaxSweets()
    {
        return maxNumSweets;
    }

    public void DropSweets()
    {
        if(numSweets <= 0) 
        { 
            noSweetsSound.Play();
            return; 
        }
        int randomPrefabIndex = UnityEngine.Random.Range(0, sweetPrefabs.Length);
        Instantiate(sweetPrefabs[randomPrefabIndex], dropPoint.position, Quaternion.identity);
        NumSweets--;
        UpdateSliderSweets();

        dropSweetSound.Play();
    }


}
