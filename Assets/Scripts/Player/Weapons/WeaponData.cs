using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon data")]
public class WeaponData : ScriptableObject
{
    public int maxAmmo;
    public int currentAmmo;
    public GameObject prefabBullet;
}
