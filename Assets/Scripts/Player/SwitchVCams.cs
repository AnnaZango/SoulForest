using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchVCams : MonoBehaviour
{
    [SerializeField] int extraPriotityOn = 10;
    CinemachineVirtualCamera aimCam;
    [SerializeField] Canvas canvasAim;


    private void Awake()
    {
        aimCam = GetComponent<CinemachineVirtualCamera>();
    }

   
    void Start()
    {
        canvasAim.enabled = false;
    }

   
    public void StartAiming()
    {
        if (GameManager.IsPlayerDead) { return; }
        aimCam.Priority += extraPriotityOn;
        canvasAim.enabled = true;
    }
    public void StopAiming()
    {
        if (GameManager.IsPlayerDead) { return; }
        aimCam.Priority -= extraPriotityOn;
        canvasAim.enabled = false;
    }
}
