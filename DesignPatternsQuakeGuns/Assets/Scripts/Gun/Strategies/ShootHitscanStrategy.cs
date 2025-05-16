using UnityEngine;

public class ShootHitscanStrategy : IShootStrategy
{
    public float distance;
    public Transform camera;
    public const float HIT_SCAN_DISTANCE = 500f;

    public ShootHitscanStrategy(Transform camera)
    {
        this.camera = camera;
        this.distance = HIT_SCAN_DISTANCE;
    }
    
    public ShootHitscanStrategy(Transform camera, float distance)
    {
        this.camera = camera;
        this.distance = distance;
    }

    /// <summary>
    /// Shoots a raycast that can damage, a damageable component
    /// </summary>
    /// <param name="damage"></param>
    public void Shoot(int damage)
    {
        Debug.Log($"Shoot: {damage}");
        RaycastHit hit;
        if (Physics.Raycast(this.camera.position, this.camera.forward, out hit, distance))
        {
            foreach (IDamageable damageable in hit.transform.GetComponents<IDamageable>())
                damageable.TakeDamage(damage);
        }
    }
}