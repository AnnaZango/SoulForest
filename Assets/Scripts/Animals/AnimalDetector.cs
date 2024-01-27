using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDetector : MonoBehaviour
{
    [SerializeField] AnimalController domesticatedAnimalInRange;


    public bool GetIfDomesticatedAnimalInRange()
    {
        return domesticatedAnimalInRange != null;
    }

    public AnimalController GetDomesticatedAnimalToRide()
    {
        return domesticatedAnimalInRange;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            if (other.gameObject.GetComponent<AnimalController>().GetIfDomesticated())
            {
                domesticatedAnimalInRange = other.GetComponent<AnimalController>();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            if (other.gameObject.GetComponent<AnimalController>() == domesticatedAnimalInRange)
            {
                domesticatedAnimalInRange = null;
            }
        }
        
    }
}
