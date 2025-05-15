using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T instance { get { return _instance; } }
    
    protected void Awake()
    {
        if (_instance != null && _instance != GetComponent<T>())
        {
            Destroy(gameObject);
        } else {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }
}
