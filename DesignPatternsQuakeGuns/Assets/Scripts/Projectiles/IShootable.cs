
using LucasCustomClasses;
using UnityEngine;

public interface IShootable : IPoolable
{
    public Rigidbody rigidbody { get; set; }
    public Vector3 spawnPosition { get; set; }
    public int damage { get; set; }
    public void Renew();
}