using Code.Runtime.Infrastructure.Interfaces;
using Code.Runtime.Infrastructure;
using Code.Runtime.Unit.Movement;
using Code.Runtime.Unit.Rotation;
using Code.Runtime.Weapon;
using Code.Runtime.Config;
using UnityEngine;
using Zenject;
using System;

namespace Code.Runtime.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerShip : MonoBehaviour, IDestroyable
    {
        [SerializeField] private UnitConfig _shipConfig;
        [SerializeField] private WeaponHolder _weaponHolder;

        private InputService _inputService;

        private PhysicsMovement _movement;
        private ShipRotation _rotation;
        private PositionClamper _clamper;

        public event Action Destroyed;

        [Inject]
        private void Construct(InputService inputService)
        {
            _inputService = inputService;

            _movement = new PhysicsMovement(GetComponent<Rigidbody2D>()
                , _shipConfig.MovementAcceleration, _shipConfig.MaxVelocity);
            _clamper = new PositionClamper(this);
            _rotation = new ShipRotation(transform, _shipConfig.RotationSpeed);
        }

        private void Update()
        {
            _clamper.ClampPosition();
        }

        public void Destroy()
        {
            
        }

        private void OnEnable()
        {
            _inputService.AccelerateButtonPressed += _movement.Move;
            _inputService.RotationButtonPressed += _rotation.Rotate;
            _inputService.UsePrimaryWeaponButtonPressed += _weaponHolder.UsePrimaryWeapon;
            _inputService.UseSecondaryWeaponButtonPressed += _weaponHolder.UseSecondaryWeapon;
        }

        private void OnDisable()
        {
            _inputService.AccelerateButtonPressed -= _movement.Move;
            _inputService.RotationButtonPressed -= _rotation.Rotate;
            _inputService.UsePrimaryWeaponButtonPressed -= _weaponHolder.UsePrimaryWeapon;
            _inputService.UseSecondaryWeaponButtonPressed -= _weaponHolder.UseSecondaryWeapon;
        }
    }
}