using Zenject;
using UnityEngine;
using Code.Runtime.Unit;
using Code.Runtime.Config;

namespace Code.Runtime.Infrastructure.Installer
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Asteroid _prefab;
        [SerializeField] private AsteroidConfig _config;

        [SerializeField] private float _prespawnTime;
        [SerializeField] private float _spawnDelay;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelBootstrapper>().AsSingle()
                .WithArguments(_prefab, _config, _prespawnTime, _spawnDelay).NonLazy();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
    }
}