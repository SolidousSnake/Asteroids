using _Project.Code.Runtime.Config;
using _Project.Code.Runtime.Core.Bootstrapper;
using _Project.Code.Runtime.Core.Factory;
using _Project.Code.Runtime.Core.States;
using _Project.Code.Runtime.MV.Model;
using _Project.Code.Runtime.Spawners;
using _Project.Code.Runtime.Unit;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Core.Installers
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private Camera _camera;
        
        public override void InstallBindings()
        {
            BindFactories();
            
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<EnemyCollection>().AsSingle();
            Container.Bind<Score>().AsSingle().NonLazy();
            
            Container.Bind<Map>().AsSingle().WithArguments(_camera);
            Container.Bind<EnemySpawner>().AsSingle().WithArguments(_levelConfig);

            Container.BindInterfacesAndSelfTo<Stopwatch>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelBootstrapper>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<AsteroidFactory>().AsSingle().WithArguments(_levelConfig);
        }
    }
}