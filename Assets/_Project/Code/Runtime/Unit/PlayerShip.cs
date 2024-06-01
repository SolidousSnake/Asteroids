using _Project.Code.Runtime.Config;
using _Project.Code.Runtime.Core.Interfaces;
using _Project.Code.Runtime.Core.States;
using _Project.Code.Runtime.MV.View;
using _Project.Code.Runtime.Services.InputService;
using _Project.Code.Runtime.Unit.Shatter.Player;
using _Project.Code.Runtime.Weapon;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerShip : MonoBehaviour, IDestroyable
    {
        [SerializeField] private UnitConfig _shipConfig;
        [SerializeField] private WeaponHolder _weaponHolder;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ParticleSystem _shatterParticles;
        
        private InputService _inputService;

        private PhysicsMovement _movement;
        private ShipRotation _rotation;
        private PositionClamper _clamper;
        private PlayerShatter _shatter;
        
        private void OnValidate()
        {
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
        }

        [Inject]
        private void Construct(InputService inputService, StateMachine stateMachine, StopwatchView stopwatchView)
        {
            _inputService = inputService;

            _movement = new PhysicsMovement(_rigidbody2D, _shipConfig.MovementAcceleration, _shipConfig.MaxVelocity);
            _clamper = new PositionClamper(this);
            _rotation = new ShipRotation(transform, _shipConfig.RotationSpeed);
            _shatter = new PlayerShatter(_shatterParticles,this, stateMachine, stopwatchView);
        }

        private void Update() => _clamper.ClampPosition();
        public void Destroy() => _shatter.Shatter();
        
        public void Spawn()
        {
            transform.position = Vector2.zero;
            gameObject.SetActive(true);
        }

        public void Despawn()
        {
            gameObject.SetActive(false);
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