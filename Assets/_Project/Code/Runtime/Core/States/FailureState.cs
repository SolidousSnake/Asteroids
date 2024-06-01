using System;
using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Core.States.View;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Data;
using _Project.Code.Runtime.MV.Model;
using _Project.Code.Runtime.Services.SaveLoadService;
using _Project.Code.Runtime.Spawners;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Core.States
{
    public sealed class FailureState : IState
    {
        [Inject] private readonly ISaveLoadService _saveLoadService;
        [Inject] private readonly FailureStateView _failureStateView;
        [Inject] private readonly StateMachine _stateMachine;
        [Inject] private readonly EnemySpawner _enemySpawner;
        [Inject] private readonly Stopwatch _stopwatch;
        [Inject] private readonly Score _score;

        public async void Enter()
        {
            Time.timeScale = Constants.Time.PausedValue;
            _stopwatch.Stop();
            _enemySpawner.Stop();
            SaveData();

            var result = await _failureStateView.Show();
            
            if(result == TargetScene.Gameplay)
                _stateMachine.Enter<RestartState>();
            else
                _stateMachine.Enter<ExitGameplayState>();
        }

        private void SaveData()
        {
            var savedProgress = _saveLoadService.Load();
            
            var playerProgress = new PlayerProgress
            {
                BestScore = Math.Max(savedProgress.BestScore, _score.GetScore()),
                BestTime = savedProgress.BestTime < _stopwatch.ElapsedTime ? _stopwatch.ElapsedTime : savedProgress.BestTime
            };
            
            _saveLoadService.Save(playerProgress);
        }

        public void Exit()
        {
            _failureStateView.Hide();
        }
    }
}