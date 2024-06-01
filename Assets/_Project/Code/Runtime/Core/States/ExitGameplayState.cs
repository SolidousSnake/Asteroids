using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Core.Util;
using Zenject;

namespace _Project.Code.Runtime.Core.States
{
    public sealed class ExitGameplayState : IState
    {
        [Inject] private readonly AssetProvider _assetProvider;
        [Inject] private readonly ISceneLoader _sceneLoader;
        
        public async void Enter()
        {
            await _assetProvider.ReleaseAssetsByLabel(Constants.AssetLabel.Level);
            _sceneLoader.LoadScene(Constants.AssetPath.MenuScene);
        }

        public void Exit()
        {
        }
    }
}