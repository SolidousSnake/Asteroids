using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.Spawners;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Shatters
{
    public sealed class BigAsteroidShatterer : IAsteroidShatterer
    {
        private readonly EnemySpawner _enemySpawner;
        public BigAsteroidShatterer(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }
        
        public void Shatter(Asteroid asteroid)
        {
            for (var i = 0; i < asteroid.SmallAsteroidsAmount; i++)
            {
                _enemySpawner.SpawnSmallAsteroid(asteroid.transform.position);
            }
            Object.Destroy(asteroid.gameObject);
        }
    }
}