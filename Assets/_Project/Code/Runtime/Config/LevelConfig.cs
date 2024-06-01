using _Project.Code.Runtime.Unit.Enemy.Asteroid;
using UnityEngine;

namespace _Project.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New level config", menuName = "Source/Config/Level")]
    public sealed class LevelConfig : ScriptableObject
    {
        [SerializeField] private BigAsteroid _bigAsteroidPrefab;
        [SerializeField] private SmallAsteroid _smallAsteroidPrefab;
        [SerializeField] private float _spawnDelay;

         public BigAsteroid BigAsteroidPrefab => _bigAsteroidPrefab;
         public SmallAsteroid SmallAsteroidPrefab => _smallAsteroidPrefab;
         public float SpawnDelay => _spawnDelay;
    }
}