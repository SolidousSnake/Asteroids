using _Project.Code.Runtime.Core.Factory;
using _Project.Code.Runtime.Core.States;
using Zenject;

namespace _Project.Code.Runtime.Core.Bootstrapper
{
    public sealed class LevelBootstrapper : IInitializable
    {
        [Inject] private readonly StateMachine _stateMachine;
        [Inject] private readonly StateFactory _stateFactory; 
        
        public void Initialize()
        {
            _stateMachine.RegisterState(_stateFactory.Create<BootstrapState>());
            _stateMachine.RegisterState(_stateFactory.Create<RestartState>());
            _stateMachine.RegisterState(_stateFactory.Create<PlayingState>());
            _stateMachine.RegisterState(_stateFactory.Create<FailureState>());
            _stateMachine.RegisterState(_stateFactory.Create<ExitGameplayState>());
            
            _stateMachine.Enter<BootstrapState>();
        }
    }
}