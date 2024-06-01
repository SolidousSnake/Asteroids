using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Services.InputService;
using _Project.Code.Runtime.Services.SaveLoadService;
using Zenject;

namespace _Project.Code.Runtime.Core.Installers
{
    public sealed class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindServices();
            BindAssetProvider();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<JsonSaveLoadService>().AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.Bind<AssetProvider>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}