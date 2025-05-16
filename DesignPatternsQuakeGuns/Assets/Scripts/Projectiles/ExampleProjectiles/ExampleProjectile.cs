using LucasCustomClasses;
using UnityEngine;

public class ExampleProjectile : IShootable
{
    public Mesh[] possibleMeshes = new Mesh[]
    {
        Resources.GetBuiltinResource<Mesh>("Cube.fbx"),
        Resources.GetBuiltinResource<Mesh>("Sphere.fbx")
    };
    public Color[] possibleColors = new Color[]
    {
        Color.red,
        Color.blue,
    };
    public bool active { get; set; }
    public GameObject gameObject { get; set; }
    public Rigidbody rigidbody { get; set; }
    public Vector3 spawnPosition { get; set; }
    public int damage { get; set; }

    public float timeTillExplosion;
    private Timer _explosionTimer;

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

    public void OnExplode()
    {
        Debug.Log($"damage: {damage}");
        DoDie();
    }
    
    public void Update(double dt)
    {
        _explosionTimer.Update(dt);
    }

    public void DoDie()
    {
        ProjectilePool.instance.GetProjectilePool(this.GetType()).DeactivateObject(this);
    }

    public IPoolable Instantiate()
    {
        ExampleProjectile projectile = new ExampleProjectile();
        ProjectileBuilder builder = new ProjectileBuilder();
        Debug.Log($"new poolable: {projectile}");
        if (gameObject == null)
        {
            builder.StartNewBuild(this);
            builder.AddRigidbody();
            builder.AddShapeComponents();
            projectile.gameObject = builder.GetProjectile();
        }

        Renew(projectile.gameObject);
        return projectile;
    }

    public void Renew()
    {
        Renew(gameObject);
    }
    public void Renew(GameObject toSetGameObject)
    {
        ProjectileBuilder.SetShape(possibleMeshes, toSetGameObject);
        ProjectileBuilder.SetColor(possibleColors, toSetGameObject);
        timeTillExplosion = Random.Range(1f, 2f);
        _explosionTimer = new Timer(timeTillExplosion, OnExplode);
    }
}
