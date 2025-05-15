using LucasCustomClasses;
using UnityEngine;

public class ExampleProjectile : MonoBehaviour, IPoolable
{
    private bool _active;
    public bool active
    {
        get { return _active; }
        set { _active = value; }
    }
    
    public void OnEnableObject()
    {
        throw new System.NotImplementedException();
    }

    public void OnDisableObject()
    {
        throw new System.NotImplementedException();
    }

    public void DoDie()
    {
        throw new System.NotImplementedException();
    }
}
