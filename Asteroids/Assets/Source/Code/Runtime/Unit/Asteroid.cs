using Code.Runtime.Infrastructure.Interfaces;
using System;
using UnityEngine;

namespace Code.Runtime.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Asteroid : MonoBehaviour, IDestroyable
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public event Action Destroyed;

        public Rigidbody2D Rigidbody => _rigidbody;

        private void OnValidate()
        {
            _rigidbody ??= GetComponent<Rigidbody2D>();
        }

        public void Destroy()
        {
            Destroyed?.Invoke();
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerShip playerShip))
            {
                playerShip.Destroy();
            }
        }
    }
}