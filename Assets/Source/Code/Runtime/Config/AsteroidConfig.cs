﻿using UnityEngine;

namespace Source.Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New asteroid config", menuName = "Source/Config/Asteroid")]
    public sealed class AsteroidConfig : ScriptableObject
    {
        [SerializeField] private float _bigAsteroidSize;
        [SerializeField] private float _smallAsteroidSize;
        [SerializeField] private float _movementSpeed;

        [SerializeField] private int _reward;
        [SerializeField] private int _smallAsteroidsAmount;
        
        public float BigAsteroidSize => _bigAsteroidSize;
        public float SmallAsteroidSize => _smallAsteroidSize;
        public float MovementSpeed => _movementSpeed;
        public int Reward => _reward;
        public int SmallAsteroidsAmount => _smallAsteroidsAmount;
    }
}