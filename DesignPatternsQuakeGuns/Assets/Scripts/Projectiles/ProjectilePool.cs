
using System.Collections.Generic;
using LucasCustomClasses;
using UnityEngine;

/// <summary>
/// Holds an object pool per projectile type
/// </summary>
public class ProjectilePool : SingletonBehaviour<ProjectilePool>
{
    public Dictionary<System.Type, ObjectPool<IShootable>> projectilePool = new();

    public ObjectPool<IShootable> GetProjectilePool(System.Type type)
    {
        if (projectilePool.TryGetValue(type, out var pool))
            return pool;
        
        ObjectPool<IShootable> newPool = new ObjectPool<IShootable>();
        projectilePool.Add(type, newPool);
        return newPool;
    }
}