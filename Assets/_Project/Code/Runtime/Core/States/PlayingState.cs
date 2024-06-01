using _Project.Code.Runtime.Core.States.View;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.MV.Model;
using _Project.Code.Runtime.MV.View;
using _Project.Code.Runtime.Spawners;
using _Project.Code.Runtime.Unit;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Core.States
{
    public sealed class PlayingState : IState
    {
        [Inject] private readonly PlayingStateView _stateView;
        [Inject] private readonly EnemySpawner _enemySpawner;
        [Inject] private readonly Stopwatch _stopwatch;
        [Inject] private readonly StopwatchView _stopwatchView;
        [Inject] private readonly PlayerShip _playerShip;
        [Inject] private readonly Score _score;
        
        public void Enter()
        {
            Time.timeScale = Constants.Time.ResumedValue;
            _stateView.gameObject.SetActive(true);
            _playerShip.Spawn();
            _stopwatchView.Subscribe();
            
            _score.Reset();
            _stopwatch.Start();
            _enemySpawner.Start();
        }

        public void Exit()
        {
            _stateView.gameObject.SetActive(false);
        }
    }
}