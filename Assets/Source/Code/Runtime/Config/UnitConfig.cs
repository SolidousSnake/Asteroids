using UnityEngine;

namespace Source.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New unit config", menuName = "Source/Config/Unit")]
    public sealed class UnitConfig : ScriptableObject
    {
        [SerializeField] private float _movementAcceleration;
        [SerializeField] private float _maxVelocity;
        [SerializeField] private float _rotationSpeed;

        public float MovementAcceleration => _movementAcceleration;
        public float MaxVelocity => _maxVelocity;
        public float RotationSpeed => _rotationSpeed;
    }
}