using _Project.Code.Runtime.MV.Model;
using _Project.Code.Runtime.Unit.Enemy.Asteroid;
using UnityEngine;

namespace _Project.Code.Runtime.Unit.Shatter
{
    public sealed class SmallAsteroidShatter : IAsteroidShatter
    {
        private readonly Score _score;

        public SmallAsteroidShatter(Score score)
        {
            _score = score;
        }
        
        public void Shatter(Asteroid asteroid)
        {
            _score.AddScore(asteroid.Reward);
            Object.Destroy(asteroid.gameObject);
        }
    }
}