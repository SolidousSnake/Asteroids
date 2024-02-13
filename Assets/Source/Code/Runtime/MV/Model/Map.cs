using Source.Code.Runtime.Core.Constants;
using UnityEngine;

namespace Source.Code.Runtime.MV.Model
{
    public sealed class Map
    {
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

             return Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        }
    }
}