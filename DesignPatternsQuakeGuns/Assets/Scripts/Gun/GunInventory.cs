
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates the user's guns on startup, handle's the gun switching logic, and gun unlocking logic
/// </summary>
public class GunInventory :  MonoBehaviour
{
    public Dictionary<KeyCode, Gun> guns = new Dictionary<KeyCode, Gun>();
    public Dictionary<KeyCode, Gun> allGuns = new Dictionary<KeyCode, Gun>();
    public Gun currentGun;
    public GameObject headCamera;

    private void Start()
    {
        GunBuilder builder = new GunBuilder();
        builder.StartNewGunBuild();
        builder.SetAmmo(1);
        builder.SetDamage(1);
        builder.SetTimings(0.2f);
        builder.SetStrategy(new ShootHitscanStrategy(headCamera.transform));
        allGuns.Add(KeyCode.Alpha1, builder.GetNewGun());
        
        builder.StartNewGunBuild();
        builder.SetAmmo(2);
        builder.SetDamage(2);
        builder.SetTimings(0.5f);
        builder.SetStrategy(new ShootHitscanStrategy(headCamera.transform));
        allGuns.Add(KeyCode.Alpha2, builder.GetNewGun());
        
        builder.StartNewGunBuild();
        builder.SetAmmo(2);
        builder.SetDamage(2);
        builder.SetTimings(0.5f);
        builder.SetStrategy(new ShootProjectileStrategy(headCamera.transform.forward, 40, new ExampleProjectile()));
        allGuns.Add(KeyCode.Alpha3, builder.GetNewGun());
        
        builder.StartNewGunBuild();
        builder.SetAmmo(4);
        builder.SetDamage(4);
        builder.SetTimings(1f);
        Vector3 shotDirection = headCamera.transform.forward + (Vector3.up * 0.5f);
        builder.SetStrategy(new ShootProjectileStrategy(shotDirection, 30, new ExampleProjectileTwo()));
        allGuns.Add(KeyCode.Alpha4, builder.GetNewGun());
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