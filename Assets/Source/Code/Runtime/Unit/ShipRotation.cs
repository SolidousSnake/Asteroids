using UnityEngine;

namespace Source.Code.Runtime.Unit
{
    public sealed class ShipRotation
    {
        private readonly Transform _context;
        private readonly float _rotationSpeed;

        private float _eulerZ;

        public ShipRotation(Transform context, float speed)
        {
            _context = context;
            _rotationSpeed = speed;
        }

        public void Rotate(float value)
        {
            _eulerZ += value * _rotationSpeed;
            _context.rotation = Quaternion.AngleAxis(_eulerZ, Vector3.forward);
        }
    }
}
