using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Security;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] float currentHealth = 10;
    [SerializeField] Slider healthSlider;

    [SerializeField] CinemachineVirtualCamera main3dCamera;
    [SerializeField] CinemachineVirtualCamera aimCamera;

    [SerializeField] GameObject volumeDie;
    [SerializeField] GameObject panelDie;

    SceneController sceneController;

    //Sounds
    [SerializeField] AudioSource soundGetHealth;
    [SerializeField] AudioSource soundGetHurt;
    [SerializeField] AudioSource soundDie;


    private void Awake()
    {
        sceneController = GameObject.FindObjectOfType<SceneController>();
    }

    void Start()
    {
        GameManager.IsPlayerDead = false;
        currentHealth = maxHealth;
        volumeDie.SetActive(false);
        panelDie.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InstaKill"))
        {
            InstaKill();
        }
    }


    public void ReceiveDamage(float damage)
    {
        if (GameManager.IsPlayerDead) { return; }

        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateSlider();

        soundGetHurt.Play();
    }

    public void ReceiveHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateSlider();
        
        soundGetHealth.Play();
    }
    public bool GetIfMaxHealth()
    {
        return currentHealth >= maxHealth;
    }

    private void Die()
    {
        if (GameManager.IsPlayerDead) { return; }

        GameManager.IsPlayerDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        Cursor.lockState = CursorLockMode.None;
        FreezeCams();
        volumeDie.SetActive(true);
        panelDie.SetActive(true);
        soundDie.Play();

        Invoke(nameof(GoToGameOver), 5);
    }


    private void GoToGameOver()
    {
        sceneController.LoadGameOver();
    }

    private void UpdateSlider()
    {
        float relativeValue = currentHealth/maxHealth;
        healthSlider.value = relativeValue;
    }

    private void InstaKill()
    {
        currentHealth = 0;
        UpdateSlider();
        Die();
    }

    public void FreezeCams()
    {
        main3dCamera.enabled = false;
        aimCamera.enabled = false;
    }
    public void UnfreezeCams()
    {
        main3dCamera.enabled = true;
        aimCamera.enabled = true;
    }
}
