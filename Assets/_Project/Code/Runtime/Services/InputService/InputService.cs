using System;
using Zenject;

namespace _Project.Code.Runtime.Services.InputService
{
    public sealed class InputService : IInitializable, ITickable, IDisposable
    {
        private readonly ShipInput _input;

        public InputService()
        {
            _input = new ShipInput();
        }

        public event Action UsePrimaryWeaponButtonPressed;
        public event Action UseSecondaryWeaponButtonPressed;
        public event Action AccelerateButtonPressed;

        public event Action<float> RotationButtonPressed;

        public void Dispose()
        {
            _input.Disable();
            _input.Dispose();
        }

        public void Initialize()
        {
            _input.Enable();

            _input.Player.UsePrimaryWeapon.performed += _ => UsePrimaryWeaponButtonPressed?.Invoke();
            _input.Player.UseSecondaryWeapon.performed += _ => UseSecondaryWeaponButtonPressed?.Invoke();
        }

        public void Tick()
        {
            if (_input.Player.Accelerate.IsPressed())
                AccelerateButtonPressed?.Invoke();

            var rotationValue = _input.Player.Rotation.ReadValue<float>();
            RotationButtonPressed?.Invoke(rotationValue);
        }
    }
}