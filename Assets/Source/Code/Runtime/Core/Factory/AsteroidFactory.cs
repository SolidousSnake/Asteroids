using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.Unit;
using UnityEngine;

namespace Source.Code.Runtime.Core.Factory
{
    public sealed class AsteroidFactory
    {
        private readonly Asteroid _prefab;

        public AsteroidFactory(Asteroid prefab)
        {
            _prefab = prefab;
        }

        public Asteroid Get(Vector2 position, IAsteroidShatterer shatter, float size)
        {
            Asteroid asteroid = Object.Instantiate(_prefab, position, Quaternion.identity);
            asteroid.Initialize(shatter, size);
         
            return asteroid;
        }
    }
}
