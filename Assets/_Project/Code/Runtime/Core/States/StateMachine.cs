using System;
using System.Collections.Generic;

namespace _Project.Code.Runtime.Core.States
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _registeredStates;
        private IState _activeState;
        
        public StateMachine()
        {
            _registeredStates = new Dictionary<Type, IState>();
        }
        
        public void RegisterState(IState state) => _registeredStates.Add(state.GetType(), state);
        
        public void RegisterState<T>(T state) where T : IState => _registeredStates.Add(typeof(T), state);

        public void Enter<T>() where T : class, IState
        {
            IState state = ChangeState<T>();
            state.Enter();
        }

        private T ChangeState<T>() where T : class, IState
        {
            _activeState?.Exit();
            T state = GetState<T>();
            _activeState = state;
            
            return state;
        }
        
        private T GetState<T>() where T : class, IState => _registeredStates[typeof(T)] as T;
    }
}