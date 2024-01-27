using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool active = false;
    PlayerHealth health;

    private void Awake()
    {
        health = GameObject.FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }


    public void PauseMode()
    {
        if (!active)
        {
            pauseMenu.SetActive(true);
            health.FreezeCams();
            Time.timeScale = 0f;
            active = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            health.UnfreezeCams();
            active = false;
        }
    }

}
