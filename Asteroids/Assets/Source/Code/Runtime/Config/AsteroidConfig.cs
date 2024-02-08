using UnityEngine;

namespace Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New asteroid config", menuName = "Source/Config/Asteroid")]
    public sealed class AsteroidConfig : ScriptableObject
    {
        [SerializeField] private float _size;
        [SerializeField] private float _movementSpeed;

        public float Size => _size;
        public float MovementSpeed => _movementSpeed;
    }
}