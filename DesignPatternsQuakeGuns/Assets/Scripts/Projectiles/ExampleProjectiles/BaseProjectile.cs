using LucasCustomClasses;
using UnityEngine;

/// <summary>
/// Handles the basic on and off logic of a projectile
/// </summary>
public class BaseProjectile : IShootable
{
    protected static readonly Mesh[] possibleMeshes = new Mesh[]{};
    protected static readonly Color[] possibleColors = new Color[]{};
    public bool active { get; set; }
    public GameObject gameObject { get; set; }
    public Rigidbody rigidbody { get; set; }
    public Vector3 spawnPosition { get; set; }
    public int damage { get; set; }

    protected float _lifeTime = 20f;
    public TimerComponent lifeTimeTimer;

    public void OnEnableObject()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPosition;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.GetComponent<Collider>().enabled = true;
        Renew();
    }

    public void OnDisableObject()
    {
        gameObject.SetActive(false);
        rigidbody.GetComponent<Collider>().enabled = false;
        rigidbody.linearVelocity = Vector3.zero;
    }

    public virtual void DoDie()
    {
        ProjectilePool.instance.GetProjectilePool(GetType()).DeactivateObject(this);
    }

    public virtual BaseProjectile MakeNewPoolable()
    {
        return new BaseProjectile();
    }

    public IPoolable Instantiate()
    {
        BaseProjectile projectile = MakeNewPoolable();
        ProjectileBuilder builder = new ProjectileBuilder();
        Debug.Log($"new poolable: {projectile}");
        if (gameObject == null)
        {
            builder.StartNewBuild(this);
            builder.AddRigidbody();
            builder.AddShapeComponents();
            projectile.gameObject = builder.newProjectile;
            projectile.lifeTimeTimer = projectile.gameObject.AddComponent<TimerComponent>();
            projectile.lifeTimeTimer.timerFinished.AddListener(projectile.DoDie);
            projectile.lifeTimeTimer.enabled = false;
        }
        return projectile;
    }

    public virtual void Renew()
    {
        lifeTimeTimer.maxTime = _lifeTime;
        lifeTimeTimer.Reset();
        lifeTimeTimer.enabled = true;
    }
}
