/// <summary>
/// this class lets you create a gun without having to call the gun class's functions (outside the builder)
/// </summary>
public class GunBuilder
{
    public Gun newGun;

    public void StartNewGunBuild()
    {
        newGun = new Gun();
    }

    public void SetAmmo(int consumption)
    {
        if (newGun == null)
            return;
        newGun.ammoConsumption = consumption;
    }

    public void SetStrategy(IShootStrategy strategy)
    {
        if (newGun == null)
            return;
        newGun.strategy = strategy;
    }

    public void SetDamage(int damage)
    {
        if (newGun == null)
            return;
        newGun.damage = damage;
    }

    /// <summary>
    /// Sets the gun's timings (currently only fire rate)
    /// </summary>
    public void SetTimings(float fireRate)
    {
        if (newGun == null)
            return;
        newGun.firerate = fireRate;
    }

    public Gun GetNewGun()
    {
        Gun setGun = new Gun(newGun);
        newGun = null;
        return setGun;
    }
}