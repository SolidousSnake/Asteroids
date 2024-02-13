using UnityEngine;

namespace Source.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New level config", menuName = "Source/Config/Level")]
    public sealed class LevelConfig : ScriptableObject
    {
        [SerializeField] private AsteroidConfig _asteroidConfig;
        [SerializeField] private float _preSpawnDelay;
        [SerializeField] private float _spawnDelay;

        public AsteroidConfig AsteroidConfig => _asteroidConfig;
        public float PreSpawnDelay => _preSpawnDelay;
        public float SpawnDelay => _spawnDelay;
    }
}