
using LucasCustomClasses;
using UnityEngine;

public interface IShootable : IPoolable
{
    public GameObject gameObject { get; set; }
    public Rigidbody rigidbody { get; set; }
    public Vector3 spawnPosition { get; set; }
    public int damage { get; set; }
    public void Update(double dt);
    public void Renew();
}