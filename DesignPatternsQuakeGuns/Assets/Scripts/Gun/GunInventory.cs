
using System;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory :  MonoBehaviour
{
    public Dictionary<KeyCode, Gun> guns = new Dictionary<KeyCode, Gun>();
    public Dictionary<KeyCode, Gun> allGuns = new Dictionary<KeyCode, Gun>();
    public Gun currentGun;
    public GameObject headCamera;

    private void Start()
    {
        GunBuilder.instance.StartNewGunBuild();
        GunBuilder.instance.SetAmmo(1);
        GunBuilder.instance.SetDamage(1);
        GunBuilder.instance.SetTimings(0.2f);
        GunBuilder.instance.SetStrategy(new ShootHitscanStrategy(headCamera.transform));
        allGuns.Add(KeyCode.Alpha1, GunBuilder.instance.GetNewGun());
        
        GunBuilder.instance.StartNewGunBuild();
        GunBuilder.instance.SetAmmo(2);
        GunBuilder.instance.SetDamage(2);
        GunBuilder.instance.SetTimings(0.5f);
        GunBuilder.instance.SetStrategy(new ShootHitscanStrategy(headCamera.transform));
        allGuns.Add(KeyCode.Alpha2, GunBuilder.instance.GetNewGun());
        
        GunBuilder.instance.StartNewGunBuild();
        GunBuilder.instance.SetAmmo(2);
        GunBuilder.instance.SetDamage(2);
        GunBuilder.instance.SetTimings(0.5f);
        GunBuilder.instance.SetStrategy(new ShootProjectileStrategy(headCamera.transform.forward, 40, new ExampleProjectile()));
        allGuns.Add(KeyCode.Alpha3, GunBuilder.instance.GetNewGun());
        
        GunBuilder.instance.StartNewGunBuild();
        GunBuilder.instance.SetAmmo(4);
        GunBuilder.instance.SetDamage(4);
        GunBuilder.instance.SetTimings(1f);
        Vector3 shotDirection = headCamera.transform.forward + (Vector3.up * 0.2f);
        GunBuilder.instance.SetStrategy(new ShootProjectileStrategy(shotDirection, 30, new ExampleProjectile()));
        allGuns.Add(KeyCode.Alpha4, GunBuilder.instance.GetNewGun());
    }

    private void Update()
    {
        foreach ((KeyCode key, Gun gun) in guns)
        {
            if (Input.GetKeyDown(key))
            {
                currentGun = gun;
                currentGun.ResetFireRate();
                Debug.Log($"Current selected: {key}, {gun}");
            }
        }
        
        currentGun?.Update(Time.deltaTime);
        
        // temp for example
        foreach ((KeyCode key, Gun gun) in allGuns)
        {
            if (Input.GetKeyDown(key) && Input.GetKey(KeyCode.Z))
            {
                UnlockGun(key);
            }
        }
    }

    public void TryShootCurrentGun()
    {
        currentGun?.Fire();
    }

    public void UnlockGun(KeyCode key)
    {
        if (!guns.ContainsKey(key) && allGuns.TryGetValue(key, out Gun gun))
        {
            guns.Add(key, gun);
            Debug.Log($"Unlocked {key}");
        }
    }
}