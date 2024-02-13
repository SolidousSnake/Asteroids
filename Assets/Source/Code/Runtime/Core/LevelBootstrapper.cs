using Cysharp.Threading.Tasks;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.MV.Model;
using Source.Code.Runtime.Spawners;
using Source.Code.Runtime.Unit;
using Zenject;

namespace Source.Code.Runtime.Core
{
    public sealed class LevelBootstrapper : IInitializable
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly float _firstSpawnDelay;
        
        public LevelBootstrapper(Asteroid asteroidPrefab, LevelConfig levelConfig, Score score)
        {
            _enemySpawner = new EnemySpawner(asteroidPrefab, levelConfig, score);
            _firstSpawnDelay = levelConfig.PreSpawnDelay;
        }

        public async void Initialize()
        {
            await UniTask.WaitForSeconds(_firstSpawnDelay);
            _enemySpawner.Initialize();
        }
    }
}