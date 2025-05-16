
using UnityEngine;

/// <summary>
/// Lets you easily create a projectile with random values
/// </summary>
public class ProjectileBuilder
{
    public GameObject newProjectile;

    public void StartNewBuild(IShootable shootable)
    {
        newProjectile = new GameObject();
        newProjectile.name = shootable.GetType().Name;
    }

    public void AddRigidbody()
    {
        if (newProjectile == null)
            return;
        newProjectile.AddComponent<Rigidbody>();
    }
    
    public void AddShapeComponents()
    {
        if (newProjectile == null)
            return;
        newProjectile.AddComponent<MeshFilter>();
        newProjectile.AddComponent<MeshRenderer>();
        MeshCollider collider = newProjectile.AddComponent<MeshCollider>();
        collider.convex = true;
    }

    public void SetShape(Mesh[] meshes)
    {
        if (newProjectile == null || meshes == null || meshes.Length == 0)
            return;
        SetShape(meshes, newProjectile);
    }
    
    public static void SetShape(Mesh[] meshes, GameObject projectile)
    {
        if (projectile == null || meshes == null || meshes.Length == 0)
            return;
        MeshFilter filter = projectile.GetComponent<MeshFilter>();
        MeshRenderer render = projectile.GetComponent<MeshRenderer>();
        MeshCollider collider = projectile.GetComponent<MeshCollider>();
        
        Mesh pickedMesh = meshes[Random.Range(0, meshes.Length)];
        collider.sharedMesh = pickedMesh;
        filter.sharedMesh = pickedMesh;
        
        render.sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
    }

    public void SetColor(Color[] colors)
    {
        if (newProjectile == null || colors == null || colors.Length == 0)
            return;
        SetColor(colors, newProjectile);
    }

    public static void SetColor(Color[] colors, GameObject projectile)
    {
        if (projectile == null || colors == null || colors.Length == 0)
            return;
        
        MeshRenderer render = projectile.GetComponent<MeshRenderer>();
        render.material.color = colors[Random.Range(0, colors.Length)];
    }
}