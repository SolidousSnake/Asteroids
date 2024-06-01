using _Project.Code.Runtime.Core.Util;
using UnityEngine;

namespace _Project.Code.Runtime.MV.Model
{
    public sealed class Map
    {
        private readonly Camera _camera;

        public Map(Camera camera)
        {
            _camera = camera;
        }
        
        public Vector2 GetRandomInnerPosition()
        {
            return Random.insideUnitCircle.normalized + Vector2.one;
        }

        public Vector2 GetRandomOuterPosition()
        {
             Vector2 viewportSpawnPosition = Vector2.zero;
             int edge = Random.Range(0, Constants.EdgeAmount);
             float offset = Random.value;

             switch (edge)
             {
                 case 0:
                     viewportSpawnPosition = new Vector2(offset, 0f);
                     break;
                 case 1:
                     viewportSpawnPosition = new Vector2(offset, 1f);
                     break;
                 case 2:
                     viewportSpawnPosition = new Vector2(0f, offset);
                     break;
                 case 3:
                     viewportSpawnPosition = new Vector2(1f, offset);
                     break;
             }

             return _camera.ViewportToWorldPoint(viewportSpawnPosition);
        }
    }
}