using Code.Runtime.Config;
using Code.Runtime.Spawners;
using Code.Runtime.Unit;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Code.Runtime.Infrastructure
{
    public sealed class LevelBootstrapper : IInitializable
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly float _prespawnDelay;

        public LevelBootstrapper(Asteroid asteroidPrefab, AsteroidConfig config, float prespawnDelay, float spawnDelay)
        {
            _enemySpawner = new EnemySpawner(asteroidPrefab, config, spawnDelay);
            _prespawnDelay = prespawnDelay;
        }

        public async void Initialize()
        {
            await UniTask.WaitForSeconds(_prespawnDelay);
            _enemySpawner.Initialize();
        }
    }
}