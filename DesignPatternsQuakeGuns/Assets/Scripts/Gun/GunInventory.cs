
using System;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory :  MonoBehaviour
{
    public Dictionary<KeyCode, Gun> guns;
    public Gun currentGun;

    private void Start()
    {
        GunBuilder.instance.StartNewGunBuild();
        GunBuilder.instance.SetAmmo(1);
        GunBuilder.instance.SetDamage(1);
        GunBuilder.instance.SetTimings(0.1f, 1f);
        guns.Add(KeyCode.Alpha1, GunBuilder.instance.GetNewGun());
    }

    private void Update()
    {
        foreach ((KeyCode key, Gun gun) in guns)
        {
            if (Input.GetKeyDown(key))
                currentGun = gun;
        }
    }
}