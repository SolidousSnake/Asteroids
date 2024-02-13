using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.MV.Model;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Shatters
{
    public sealed class SmallAsteroidShatterer : IAsteroidShatterer
    {
        private readonly Score _score;
        private readonly int _reward;

        public SmallAsteroidShatterer(Score score, int reward)
        {
            _score = score;
            _reward = reward;
        }
        
        public void Shatter(Asteroid asteroid)
        {
            _score.AddScore(_reward);
            Object.Destroy(asteroid.gameObject);
        }
    }
}