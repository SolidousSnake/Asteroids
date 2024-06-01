using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.Util;
using Zenject;

namespace _Project.Code.Runtime.Core.States
{
    public sealed class BootstrapState : IState
    {
        [Inject] private readonly StateMachine _stateMachine;
        [Inject] private readonly AssetProvider _assetProvider;
        
        public async void Enter()
        {
            await _assetProvider.WarmupAssetsByLabel(Constants.AssetLabel.Level);

            _stateMachine.Enter<PlayingState>();
        }

        public void Exit()
        {
        }
    }
}