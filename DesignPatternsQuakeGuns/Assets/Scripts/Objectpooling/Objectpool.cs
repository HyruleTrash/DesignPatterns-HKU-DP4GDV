using System.Collections.Generic;
using Unity.VisualScripting;

namespace LucasCustomClasses
{
    public class ObjectPool<T> where T : IPoolable
    {
        public List<T> activePool = new List<T>();
        private List<T> _inactivePool = new List<T>();

        public void AddNewObject(T newObject)
        {
            if (newObject == null)
                return;
            if (newObject.active)
                activePool.Add(newObject);
            else
                _inactivePool.Add(newObject);
        }

        public T GetInactiveObject(out bool result)
        {
            if (_inactivePool.Count > 0)
            {
                result = true;
                return _inactivePool[0];
            }
            else
            {
                result = false;
                return default(T);
            }
        }

        public T ActivateObject(T relevantObject)
        {
            relevantObject.OnEnableObject();
            relevantObject.active = true;
            if (_inactivePool.Contains(relevantObject))
            {
                _inactivePool.Remove(relevantObject);
            }
            activePool.Add(relevantObject);
            return relevantObject;
        }

        public void DeactivateObject(T relevantObject)
        {
            relevantObject.OnDisableObject();
            relevantObject.active = false;
            if (activePool.Contains(relevantObject))
            {
                activePool.Remove(relevantObject);
            }
            _inactivePool.Add(relevantObject);
        }
    }
}