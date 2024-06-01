using _Project.Code.Runtime.MV.Model;
using _Project.Code.Runtime.Unit;
using Zenject;

namespace _Project.Code.Runtime.Core.States
{
    public sealed class RestartState : IState
    {
        [Inject] private readonly StateMachine _stateMachine;
        [Inject] private readonly EnemyCollection _enemyCollection;
        [Inject] private readonly Score _score;
        [Inject] private readonly Stopwatch _stopwatch;
        
        public void Enter()
        {
            _enemyCollection.CleanUp();
            _score.Reset();
            _stopwatch.Reset();

            _stateMachine.Enter<PlayingState>();
        }
        
        public void Exit()
        {
        }
    }
}