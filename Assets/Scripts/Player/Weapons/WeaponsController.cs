using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsController : MonoBehaviour
{
    [SerializeField] Transform weaponsParent;
    [SerializeField] int currentWeaponIndex = 0;
    [SerializeField] WeaponData[] weapons;
    [SerializeField] Image[] weaponsAmmoImages;
    [SerializeField] Image[] weaponsAmmoImagesBackgrounds;

    [SerializeField] Color32[] colorsActiveAmmo;
    [SerializeField] Color32 colorActiveAmmoBackground;

    [SerializeField] bool[] activeWeapons = new bool[3];
    bool enableSwitchSound = false;

    //Sounds
    [SerializeField] AudioSource pickupNewWeapon;
    [SerializeField] AudioSource switchWeapons;

    void Start()
    {
        activeWeapons[currentWeaponIndex] = true;
        weaponsAmmoImages[currentWeaponIndex].color = colorsActiveAmmo[currentWeaponIndex];
        weaponsAmmoImagesBackgrounds[currentWeaponIndex].color = colorActiveAmmoBackground;

        foreach (WeaponData weapon in weapons)
        {
            weapon.currentAmmo = weapon.maxAmmo;
        }
    }

   
    public void SwitchWeapons()
    {
        currentWeaponIndex++;
        if (currentWeaponIndex > weaponsParent.childCount - 1)
        {
            currentWeaponIndex = 0;
        }

        if (activeWeapons[currentWeaponIndex] == false ) 
        {  
            SwitchWeapons(); //go to the next until finding an active one
        }
        else
        {            
            foreach (Transform child in weaponsParent)
            {
                child.gameObject.SetActive(false);
            }
            weaponsParent.GetChild(currentWeaponIndex).gameObject.SetActive(true);            
        } 
        
        if(enableSwitchSound)
        {
            switchWeapons.Play();
        }
    }

    public void ActivateWeapon(int indexWeapon)
    {
        activeWeapons[indexWeapon] = true;
        currentWeaponIndex = indexWeapon;
        foreach (Transform child in weaponsParent)
        {
            child.gameObject.SetActive(false);
        }
        weaponsParent.GetChild(currentWeaponIndex).gameObject.SetActive(true);

        weaponsAmmoImages[indexWeapon].color = colorsActiveAmmo[indexWeapon];
        weaponsAmmoImagesBackgrounds[indexWeapon].color = colorActiveAmmoBackground;

        pickupNewWeapon.Play();
        if(!enableSwitchSound)
        {
            enableSwitchSound = true;
        }
    }

    public bool GetIfAmmoLeft()
    {
        return weapons[currentWeaponIndex].currentAmmo > 0;
    }

    public GameObject GetCurrentPrefabBullet()
    {
        weapons[currentWeaponIndex].currentAmmo--;
        UpdateAmmoUI();
        return weapons[currentWeaponIndex].prefabBullet;
    }

    private void UpdateAmmoUI()
    {
        for (int i = 0; i < weaponsAmmoImages.Length; i++)
        {
            float ammoWeapon = (float)weapons[i].currentAmmo / (float)weapons[i].maxAmmo;
            weaponsAmmoImages[i].fillAmount = ammoWeapon;
        }
    }

    public void RefillAmmo(int indexAmmo)
    {
        if (activeWeapons[indexAmmo] == false) { return; } //if weapon not active, return
        weapons[indexAmmo].currentAmmo = weapons[indexAmmo].maxAmmo;
        UpdateAmmoUI();
    }

    public bool GetIfMaxAmmo(int indexAmmo)
    {
        return weapons[indexAmmo].currentAmmo >= weapons[indexAmmo].maxAmmo;
    }
}
