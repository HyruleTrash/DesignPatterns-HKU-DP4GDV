
using LucasCustomClasses;
using UnityEngine;

public class ShootProjectileStrategy : IShootStrategy
{
    public IShootable projectilePrefab;
    public Vector3 direction;
    public float force;

    public ShootProjectileStrategy(Vector3 direction, float force, IShootable projectilePrefab)
    {
        this.direction = direction.normalized;
        this.force = force;
        this.projectilePrefab = projectilePrefab;
    }

    public void Shoot(int damage)
    {
        ObjectPool<IShootable>.GetNewPoolable(out var projectile, ProjectilePool.instance.GetProjectilePool(projectilePrefab.GetType()), projectilePrefab);
        ProjectilePool.instance.GetProjectilePool(projectilePrefab.GetType()).ActivateObject(projectile);
        projectile.damage = damage;
        projectile.rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}