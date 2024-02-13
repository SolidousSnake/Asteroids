using System;
using Source.Code.Runtime.MV.View;

namespace Source.Code.Runtime.MV.Model
{
    public sealed class Score
    {
        private readonly ScoreView _scoreView;
        private int _score;

        public Score(ScoreView scoreView)
        {
            _score = 0;
            _scoreView = scoreView;
        }

        public void AddScore(int value)
        {
            if (value < 0)
                throw new InvalidOperationException($"value must be positive {value}");
            
            _score += value;
            _scoreView.SetAmount(_score);
        }
    }
}