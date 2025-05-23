using LucasCustomClasses;
using UnityEngine;

public class ExampleProjectile : BaseProjectile
{
    protected new static readonly Mesh[] possibleMeshes = new Mesh[]
    {
        Resources.GetBuiltinResource<Mesh>("Cube.fbx"),
        Resources.GetBuiltinResource<Mesh>("Sphere.fbx")
    };
    protected new static readonly Color[] possibleColors = new Color[]
    {
        Color.red,
        Color.blue,
    };
    
    public override void DoDie()
    {
        ProjectilePool.instance.GetProjectilePool(GetType()).DeactivateObject(this);
    }
    
    public override BaseProjectile MakeNewPoolable()
    {
        return new ExampleProjectile();
    }

    public override void Renew()
    {
        base.Renew();
        ProjectileBuilder.SetShape(possibleMeshes, gameObject);
        ProjectileBuilder.SetColor(possibleColors, gameObject);
    }
}
