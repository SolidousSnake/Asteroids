using _Project.Code.Runtime.Core.States;
using Zenject;

namespace _Project.Code.Runtime.Core.Factory
{
    public sealed class StateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T Create<T>() where T : IState => _instantiator.Instantiate<T>();
    }
}