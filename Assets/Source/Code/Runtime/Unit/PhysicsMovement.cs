using UnityEngine;

namespace Source.Code.Runtime.Unit
{
    public sealed class PhysicsMovement
    {
        private readonly Rigidbody2D _rigidBody;

        private readonly float _movementSpeed;
        private readonly float _maxSpeed;

        public PhysicsMovement(Rigidbody2D rigidBody, float speed, float maxSpeed)
        {
            _rigidBody = rigidBody;
            _movementSpeed = speed;
            _maxSpeed = maxSpeed;
        }

        public void Move()
        {
            _rigidBody.AddForce(_rigidBody.transform.up * _movementSpeed);
            _rigidBody.velocity = Vector2.ClampMagnitude(_rigidBody.velocity, _maxSpeed);
        }
    }
}
