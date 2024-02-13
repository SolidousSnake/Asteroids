using UnityEngine;

namespace Source.Code.Runtime.Core.Factory
{
    public abstract class Factory<T> where T : MonoBehaviour
    {
        private readonly T _prefab;

        public Factory(T prefab) 
        {
            _prefab = prefab;
        }
        
        public T Get()
        {
            return Object.Instantiate(_prefab);
        }

        public T Get(Vector2 position)
        {
            return Object.Instantiate(_prefab, position, Quaternion.identity);
        }

        public T Get(Transform transform)
        {
            return Object.Instantiate(_prefab, transform.position, transform.rotation);
        }
    }
}
