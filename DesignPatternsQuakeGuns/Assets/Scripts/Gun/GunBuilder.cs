
public class GunBuilder : SingletonBehaviour<GunBuilder>
{
    public Gun newGun;

    public void StartNewGunBuild()
    {
        newGun = new Gun();
    }

    public void SetAmmo(int consumption)
    {
        
    }

    public void SetStrategy(IShootStrategy strategy)
    {
        newGun.strategy = strategy;
    }

    public void SetDamage(int damage)
    {
        
    }

    public Gun GetNewGun()
    {
        return newGun;
    }
}