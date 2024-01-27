using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalBehavior : MonoBehaviour, IDamageable
{
    [SerializeField] float trustLevel = 0f;
    [SerializeField] GameObject heartTrust;
    [SerializeField] Image imageHeartFill;
    [SerializeField] float timeBetweenDecreaseTrust = 60f;
    [SerializeField] float decreaseTrustAmountOverTime = 0.05f;
    [SerializeField] float decreaseTrustWhenHurt = 0.3f;
    Animator animator;
 

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public float TrustLevel
    {
        get { return trustLevel; }
        set 
        { 
            trustLevel = Mathf.Clamp01(value);
            UpdateHeartTrust();
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(DecreaseTrust), 0, timeBetweenDecreaseTrust);
        UpdateHeartTrust();
    }


    //Trust goes down even when riding animal, to make it harder to keep animals happy. If we wanted to enable and disable, use Coroutine and start it
    //or stop it on OnEnable() and OnDisable().
    private void DecreaseTrust() 
    {
        if (TrustLevel > 0f)
        {
            TrustLevel -= decreaseTrustAmountOverTime;
        }
    }

    private void UpdateHeartTrust()
    {
        imageHeartFill.fillAmount = trustLevel;
    }

    public void ReceiveDamage(float damage)
    {
        animator.SetTrigger("hurt");
        TrustLevel -= decreaseTrustWhenHurt;
    }

    
}
