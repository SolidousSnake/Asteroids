using _Project.Code.Runtime.Config;
using _Project.Code.Runtime.Unit.Enemy.Asteroid;
using _Project.Code.Runtime.Unit.Shatter;
using UnityEngine;

namespace _Project.Code.Runtime.Core.Factory
{
    public sealed class AsteroidFactory
    {
        private readonly BigAsteroid _bigAsteroid;
        private readonly SmallAsteroid _smallAsteroid;
        
        public AsteroidFactory(LevelConfig config)
        {
            _bigAsteroid = config.BigAsteroidPrefab;
            _smallAsteroid = config.SmallAsteroidPrefab;
        }
        
        public BigAsteroid CreateBig(Vector2 position, Vector2 direction, IAsteroidShatter shatter)
        {
            BigAsteroid asteroid = Object.Instantiate(_bigAsteroid, position, Quaternion.identity);
            asteroid.Initialize(direction, shatter);
            return asteroid;
        }

        public SmallAsteroid CreateSmall(Vector2 position, Vector2 direction, IAsteroidShatter shatter)
        {
            SmallAsteroid asteroid = Object.Instantiate(_smallAsteroid, position, Quaternion.identity);
            asteroid.Initialize(direction, shatter);
            return asteroid;
        }
    }
}
