using Code.Runtime.Config;
using Code.Runtime.Infrastructure.Factory;
using Code.Runtime.Unit;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Runtime.Spawners
{
    public sealed class EnemySpawner
    {
        private readonly AsteroidFactory _factory;
        private readonly AsteroidConfig _asteroidConfig;
        private readonly float _spawnDelay;

        public EnemySpawner(Asteroid asteroidPrefab, AsteroidConfig config, float spawnDelay)
        {
            _factory = new AsteroidFactory(asteroidPrefab);
            _spawnDelay = spawnDelay;
            _asteroidConfig = config;
        }

        public void Initialize() 
        {
            Spawn().Forget();
        }
        
        public async UniTaskVoid Spawn()
        {           
            Asteroid asteroid =  _factory.Get(GetPosition());

            
            Vector2 direction = new Vector2(Random.value, Random.value).normalized;
            asteroid.Rigidbody.AddForce(direction * 4f);

            await UniTask.WaitForSeconds(_spawnDelay);
        }

        private Vector2 GetPosition()
        {
            Vector2 viewportSpawnPosition = Vector2.zero;
            int edge = Random.Range(0, Constants.Constants.EdgeAmount);
            float offset = Random.Range(0f, 1f);

            switch (edge)
            {
                case 0:
                    viewportSpawnPosition = new Vector2(offset, 0f);
                    break;
                case 1:
                    viewportSpawnPosition = new Vector2(offset, 1f);
                    break;
                case 2:
                    viewportSpawnPosition = new Vector2(0f, offset);
                    break;
                case 3:
                    viewportSpawnPosition = new Vector2(1f, offset);
                    break;
            }

            return Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        }
    }
}
