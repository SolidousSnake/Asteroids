using UnityEngine;

namespace _Project.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New weapon config", menuName = "Source/Config/Weapon")]
    public sealed class WeaponConfig : ScriptableObject
    {
        [SerializeField] private float _range;
        [SerializeField] private float _fireDelay;

        public float Range => _range;
        public float FireDelay => _fireDelay;
    }
}