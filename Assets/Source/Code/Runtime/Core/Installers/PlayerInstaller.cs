using Source.Code.Runtime.Unit;
using UnityEngine;
using Zenject;

namespace Source.Code.Runtime.Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerShip _playerPrefab;
        [SerializeField] private Vector3 _spawnPoint;

        public override void InstallBindings()
        {
            var instance = Container.InstantiatePrefabForComponent<PlayerShip>(
                _playerPrefab, _spawnPoint, Quaternion.identity, null);

            Container.Bind<PlayerShip>().FromInstance(instance).AsSingle();
        }
    }
}