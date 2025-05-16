
public class GunBuilder : SingletonBehaviour<GunBuilder>
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