using LucasCustomClasses;
using UnityEngine;

/// <summary>
/// Holds the logic for ammo consumption and fire rate.
/// Also calls the firing logic inside the set strategy
/// </summary>
public class Gun
{
    public IShootStrategy strategy;
    public int damage;
    public int ammoConsumption;
    
    public float firerate;
    private Timer _fireRateTimer;
    private bool _canFire = true;

    public Gun()
    {
    }

    public Gun(Gun other)
    {
        strategy = other.strategy;
        ammoConsumption = other.ammoConsumption;
        damage = other.damage;
        firerate = other.firerate;
    }

    public void Fire()
    {
        if (strategy == null || PlayerData.instance.CurrentAmmo < ammoConsumption || !_canFire)
            return;
        _canFire = false;
        ResetFireRate();
        strategy.Shoot(damage);
        PlayerData.instance.CurrentAmmo -= ammoConsumption;
        Debug.Log($"Ammo: {PlayerData.instance.CurrentAmmo}");
    }

    public void ResetFireRate()
    {
        _fireRateTimer = new Timer(firerate, () => { _canFire = true;});
    }

    public void Update(double dt)
    {
        if (!_canFire)
            _fireRateTimer.Update(dt);
    }
}