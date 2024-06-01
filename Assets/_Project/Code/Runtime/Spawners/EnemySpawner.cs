using System;
using System.Threading;
using _Project.Code.Runtime.Config;
using _Project.Code.Runtime.Core.Factory;
using _Project.Code.Runtime.MV.Model;
using _Project.Code.Runtime.Unit;
using _Project.Code.Runtime.Unit.Shatter;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Code.Runtime.Spawners
{
    public sealed class EnemySpawner
    {
        private readonly AsteroidFactory _factory;
        private readonly Map _map;
        private readonly EnemyCollection _enemyCollection;

        private readonly BigAsteroidShatter _bigAsteroidShatter;
        private readonly SmallAsteroidShatter _smallAsteroidShatter;
        private CancellationTokenSource _cts;
        private readonly float _spawnDelay;

        public EnemySpawner(LevelConfig levelConfig, Map map, AsteroidFactory factory, EnemyCollection enemyCollection
            , Score score)
        {
            _spawnDelay = levelConfig.SpawnDelay;
            _map = map;
            _factory = factory;
            _enemyCollection = enemyCollection;

            _bigAsteroidShatter = new BigAsteroidShatter(this);
            _smallAsteroidShatter = new SmallAsteroidShatter(score);
        }

        public void Start()
        {
            _cts = new CancellationTokenSource();
            SpawnBigAsteroidRepeatedly().Forget();
        }

        public void Stop() => _cts.Cancel();
        
        public async UniTaskVoid SpawnBigAsteroidRepeatedly()
        {
            while (!_cts.IsCancellationRequested)
            {
                SpawnBigAsteroid();
                await UniTask.WaitForSeconds(_spawnDelay, cancellationToken: _cts.Token);
            }
        }

        private void SpawnBigAsteroid()
        {
            Vector2 position = _map.GetRandomOuterPosition();
            Vector2 direction = (_map.GetRandomInnerPosition() - position).normalized;

            var asteroid = _factory.CreateBig(position, direction, _bigAsteroidShatter);
            _enemyCollection.Add(asteroid);
        }

        public void SpawnSmallAsteroid(Vector2 position)
        {
            Vector2 direction = (_map.GetRandomOuterPosition() - position).normalized;

            var asteroid = _factory.CreateSmall(position, direction, _smallAsteroidShatter);
            _enemyCollection.Add(asteroid);
        }
    }
}