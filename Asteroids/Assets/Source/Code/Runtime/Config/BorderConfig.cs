using UnityEngine;

namespace Code.Runtime.Config
{
    [CreateAssetMenu(fileName = "New border config", menuName = "Source/Config/Border")]
    public sealed class BorderConfig : ScriptableObject
    {
        [SerializeField] private float _topBoundary;
        [SerializeField] private float _bottomBoundary;
        [SerializeField] private float _leftBoundary;
        [SerializeField] private float _rightBoundary;

        public float TopBoundary => _topBoundary;
        public float BottomBoundary => _bottomBoundary;
        public float LeftBoundary => _leftBoundary;
        public float RightBoundary => _rightBoundary;
    }
}