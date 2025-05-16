using LucasCustomClasses;
using UnityEngine;

public class ExampleProjectileTwo : BaseProjectile
{
    protected new static readonly Mesh[] possibleMeshes = new Mesh[]
    {
        Resources.GetBuiltinResource<Mesh>("Cylinder.fbx"),
        Resources.GetBuiltinResource<Mesh>("Capsule.fbx")
    };
    protected new static readonly Color[] possibleColors = new Color[]
    {
        Color.magenta,
        Color.yellow,
    };
    
    public override void DoDie()
    {
        Debug.Log($"Explosion! damage: {damage}");
        ProjectilePool.instance.GetProjectilePool(GetType()).DeactivateObject(this);
    }
    
    public override BaseProjectile MakeNewPoolable()
    {
        return new ExampleProjectileTwo();
    }

    public override void Renew()
    {
        base.Renew();
        ProjectileBuilder.SetShape(possibleMeshes, gameObject);
        ProjectileBuilder.SetColor(possibleColors, gameObject);
        _lifeTime = Random.Range(4f, 5f);
    }
}
