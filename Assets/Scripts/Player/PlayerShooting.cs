using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform transformMainCam;
    [SerializeField] Transform shootingPoint;
    [SerializeField] WeaponsController weaponsController;

    Animator animator;
    PlayerController playerController;
    int shootParameter;
    [SerializeField] float animationPlaytimeShoot = 0.05f;

    //Sounds
    [SerializeField] AudioSource soundNoAmmo;

    private LayerMask raycastShootingLayermask; 
    


    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        weaponsController = GetComponent<WeaponsController>();
        transformMainCam = Camera.main.transform;
        shootParameter = Animator.StringToHash("Shoot");
        raycastShootingLayermask = LayerMask.GetMask("Environment") | LayerMask.GetMask("Default");
    }



    public void ProcessShooting()
    {
        if (GameManager.IsPlayerDead) { return; }
        animator.CrossFade(shootParameter, animationPlaytimeShoot);
    }

    public void ShootInAnimation() //Called as an event in the animation
    {
        if (playerController.IsPlayerDashing()) { return; } //cannot shoot while dashing

        if (!weaponsController.GetIfAmmoLeft())
        {
            soundNoAmmo.Play();
            return;
        }

        RaycastHit hit;

        GameObject bulletInstance = Instantiate(weaponsController.GetCurrentPrefabBullet(), shootingPoint.position, Quaternion.identity);
        BulletController bulletController = bulletInstance.GetComponent<BulletController>();

        if (Physics.Raycast(transformMainCam.position, transformMainCam.forward, out hit, Mathf.Infinity, raycastShootingLayermask)) //if we hit sth
        {            
            bulletController.target = hit.point;
            if (hit.collider.GetComponent<IDamageable>() != null)
            {
                //we pass on the damageable element
                bulletController.damageableElement = hit.collider.GetComponent<IDamageable>();
            }
        }
        else //if we don't hit anything
        {           
            bulletController.target = transformMainCam.position + transformMainCam.forward * 30; //we set the target as a point in the  cam forward distance
        }
    }
}
