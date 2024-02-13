using Source.Code.Runtime.Config;
using Source.Code.Runtime.MV.Model;
using Source.Code.Runtime.Unit;
using UnityEngine;
using Zenject;

namespace Source.Code.Runtime.Core.Installers
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Asteroid _prefab;
        [SerializeField] private LevelConfig _levelConfig;

        public override void InstallBindings()
        {
            Container.Bind<Score>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Timer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

            Container.BindInterfacesAndSelfTo<LevelBootstrapper>().AsSingle()
                .WithArguments(_prefab, _levelConfig).NonLazy();
        }
    }
}