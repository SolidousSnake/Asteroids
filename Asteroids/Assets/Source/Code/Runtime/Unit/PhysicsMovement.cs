using UnityEngine;

namespace Code.Runtime.Unit.Movement
{
    public sealed class PhysicsMovement
    {
        private readonly Rigidbody2D _rigidbody;

        private readonly float _movementSpeed;
        private readonly float _maxSpeed;

        public PhysicsMovement(Rigidbody2D rigidbody, float speed, float maxSpeed)
        {
            _rigidbody = rigidbody;
            _movementSpeed = speed;
            _maxSpeed = maxSpeed;
        }

        public void Move()
        {
            _rigidbody.AddForce(_rigidbody.transform.up * _movementSpeed);
            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
        }
    }
}
