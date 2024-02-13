using System.Threading;
using Cysharp.Threading.Tasks;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.Factory;
using Source.Code.Runtime.Unit;
using Source.Code.Runtime.MV.Model;
using Source.Code.Runtime.Unit.Shatters;
using UnityEngine;

namespace Source.Code.Runtime.Spawners
{
    public sealed class EnemySpawner
    {
        private readonly AsteroidFactory _factory;
        private readonly AsteroidConfig _asteroidConfig;
        private readonly float _spawnDelay;

        private readonly Map _map;
        private readonly BigAsteroidShatterer _bigAsteroidShatterer;
        private readonly SmallAsteroidShatterer _smallAsteroidShatterer;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public EnemySpawner(Asteroid asteroidPrefab, LevelConfig config, Score score)
        {
            _spawnDelay = config.SpawnDelay;
            _asteroidConfig = config.AsteroidConfig;
            
            _map = new Map();
            _factory = new AsteroidFactory(asteroidPrefab);
            _bigAsteroidShatterer = new BigAsteroidShatterer(this);
            _smallAsteroidShatterer = new SmallAsteroidShatterer(score, _asteroidConfig.Reward);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Initialize() 
        {
            SpawnBigAsteroid().Forget();
        }

        private async UniTaskVoid SpawnBigAsteroid()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                Vector2 position = _map.GetRandomOuterPosition();
                Vector2 direction = (_map.GetRandomInnerPosition() - position).normalized;
                Asteroid asteroid =  _factory.Get(position, _bigAsteroidShatterer, _asteroidConfig.BigAsteroidSize);

                asteroid.Push(direction);
                
                await UniTask.WaitForSeconds(_spawnDelay);
            }
        }

        public void SpawnSmallAsteroid(Vector2 position)
        {
            Vector2 direction = (_map.GetRandomOuterPosition() - position).normalized;
            Asteroid asteroid =  _factory.Get(position, _smallAsteroidShatterer, _asteroidConfig.SmallAsteroidSize);

            asteroid.Push(direction);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
