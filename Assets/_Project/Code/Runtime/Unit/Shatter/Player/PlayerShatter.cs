using _Project.Code.Runtime.Core.States;
using _Project.Code.Runtime.MV.View;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Code.Runtime.Unit.Shatter.Player
{
    public class PlayerShatter
    {
        private readonly ParticleSystem _particleSystem;
        private readonly PlayerShip _playerShip;
        private readonly StateMachine _stateMachine;
        private readonly StopwatchView _stopwatchView;

        public PlayerShatter(ParticleSystem particleSystem, PlayerShip ship, StateMachine stateMachine,
            StopwatchView stopwatchView)
        {
            _particleSystem = particleSystem;
            _playerShip = ship;
            _stateMachine = stateMachine;
            _stopwatchView = stopwatchView;
        }

        public async void Shatter()
        {
            _playerShip.Despawn();
            _stopwatchView.Unsubscribe();
            Object.Instantiate(_particleSystem, _playerShip.transform.position, _playerShip.transform.rotation);
            await UniTask.WaitForSeconds(_particleSystem.main.duration);
            _stateMachine.Enter<FailureState>();
        }
    }
}