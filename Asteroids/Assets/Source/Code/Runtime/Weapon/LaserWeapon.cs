using Code.Runtime.Config;
using Code.Runtime.Infrastructure.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Runtime.Weapon
{
    public sealed class LaserWeapon : MonoBehaviour, IShipWeapon
    {
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private Transform _muzzle;

        [SerializeField] private LineRenderer _lineRenderer;

        private void Start()
        {
            _lineRenderer.enabled = false;
        }

        public async UniTaskVoid Use()
        {
            _lineRenderer.enabled = true;

            RaycastHit2D hit = Physics2D.Raycast(_muzzle.position, _muzzle.up, _config.Range);
            _lineRenderer.SetPosition(0, _muzzle.position);
            if (hit)
            {
                _lineRenderer.SetPosition(1, hit.point);                
            }
            else
            {
                _lineRenderer.SetPosition(1, _muzzle.up * _config.Range);
            }

            await UniTask.WaitForSeconds(_config.FireDelay);
            _lineRenderer.enabled = false;
        }
    }
}