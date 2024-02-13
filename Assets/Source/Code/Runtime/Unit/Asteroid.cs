using System;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.Interfaces;
using UnityEngine;

namespace Source.Code.Runtime.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Asteroid : MonoBehaviour, IDestroyable
    {
        [SerializeField] private AsteroidConfig _config;
        [SerializeField] private Rigidbody2D _rigidBody;

        private IAsteroidShatterer _shatterer;

        public int SmallAsteroidsAmount => _config.SmallAsteroidsAmount;
        
        private void OnValidate()
        {
            _rigidBody ??= GetComponent<Rigidbody2D>();
        }
 
        public void Initialize(IAsteroidShatterer shatter, float size)
        {
            _shatterer = shatter;
            transform.localScale = new Vector2(size, size);
        }

        public void Push(Vector2 direction)
        {
            _rigidBody.AddForce(direction * _config.MovementSpeed);
        }
        
        public void Destroy()
        {
            _shatterer.Shatter(this);
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