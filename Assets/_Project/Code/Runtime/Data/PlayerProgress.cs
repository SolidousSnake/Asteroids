using System;

namespace _Project.Code.Runtime.Data
{
    [Serializable]
    public sealed class PlayerProgress
    {
        public TimeSpan BestTime;
        public int BestScore;
    }
}