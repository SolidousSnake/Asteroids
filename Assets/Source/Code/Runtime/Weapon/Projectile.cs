using Source.Code.Runtime.Core.Interfaces;
using UnityEngine;

namespace Source.Code.Runtime.Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField] private float _lifetime;
        
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D Rigidbody => _rigidbody;

        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize()
        {
            Destroy(gameObject, _lifetime);
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.TryGetComponent(out IDestroyable destroyable)) 
            {
                destroyable.Destroy();
            }
            Destroy(gameObject);
        }
    }
}