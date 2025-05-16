public class Gun
{
    public IShootStrategy strategy;
    public int ammoConsumption;
    public int damage;
    public float reloadTime;
    public float firerate;

    public Gun()
    {
    }

    public Gun(Gun other)
    {
        strategy = other.strategy;
        ammoConsumption = other.ammoConsumption;
        damage = other.damage;
        reloadTime = other.reloadTime;
        firerate = other.firerate;
    }
}