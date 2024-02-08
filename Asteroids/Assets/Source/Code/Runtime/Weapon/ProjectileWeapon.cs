using Cysharp.Threading.Tasks;
using Code.Runtime.Infrastructure.Interfaces;
using Code.Runtime.Config;
using UnityEngine;

namespace Code.Runtime.Weapon
{
    public sealed class ProjectileWeapon : MonoBehaviour, IShipWeapon
    {
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private Transform _muzzle;

        [SerializeField] private Projectile _projectilePrefab;

        public async UniTaskVoid Use()
        {
            Projectile projectile = Instantiate(_projectilePrefab, _muzzle.position, _muzzle.rotation);

            projectile.Initialize();
            projectile.Rigidbody.AddForce(_config.Range * _muzzle.up, ForceMode2D.Impulse);

            await UniTask.WaitForSeconds(_config.FireDelay);
        }
    }
}