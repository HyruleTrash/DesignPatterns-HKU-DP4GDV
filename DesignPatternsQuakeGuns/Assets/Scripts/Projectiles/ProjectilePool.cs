
using System.Collections.Generic;
using LucasCustomClasses;
using UnityEngine;

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

    private void Update()
    {
        foreach ((System.Type key, ObjectPool<IShootable> pool) in projectilePool)
        {
            List<IShootable> currentActive = new List<IShootable>(pool.activePool);
            foreach (var objectShootable in currentActive)
            {
                objectShootable.Update(Time.deltaTime);
            }
        }
    }
}