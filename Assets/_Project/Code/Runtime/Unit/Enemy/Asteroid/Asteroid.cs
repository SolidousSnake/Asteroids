using _Project.Code.Runtime.Config;
using _Project.Code.Runtime.Core.Interfaces;
using _Project.Code.Runtime.Unit.Shatter;
using UnityEngine;

namespace _Project.Code.Runtime.Unit.Enemy.Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Asteroid : MonoBehaviour, IDestroyable
    {
        [SerializeField] private AsteroidConfig _config;
        [SerializeField] private Rigidbody2D _rigidBody;

        private IAsteroidShatter _shatter;

        public int SmallAsteroidsAmount => _config.SmallAsteroidsAmount;
        public int Reward => _config.Reward;
        
        private void OnValidate()
        {
            _rigidBody ??= GetComponent<Rigidbody2D>();
        }
 
        public void Initialize(Vector2 direction, IAsteroidShatter shatter)
        {
            _shatter = shatter;
            _rigidBody.AddForce(direction * _config.MovementSpeed);
        }
        
        public void Destroy()
        {
            _shatter.Shatter(this);
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