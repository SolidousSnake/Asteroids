using _Project.Code.Runtime.Spawners;
using _Project.Code.Runtime.Unit.Enemy.Asteroid;
using UnityEngine;

namespace _Project.Code.Runtime.Unit.Shatter
{
    public sealed class BigAsteroidShatter : IAsteroidShatter
    {
        private readonly EnemySpawner _enemySpawner;

        public BigAsteroidShatter(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }
        
        public void Shatter(Asteroid asteroid)
        {
            for (var i = 0; i < asteroid.SmallAsteroidsAmount; i++) 
                _enemySpawner.SpawnSmallAsteroid(asteroid.transform.position);
            
            Object.Destroy(asteroid.gameObject);
        }
    }
}