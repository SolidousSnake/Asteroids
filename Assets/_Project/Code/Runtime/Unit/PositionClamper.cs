using UnityEngine;

namespace _Project.Code.Runtime.Unit
{
    public sealed class PositionClamper
    {
        private readonly Transform _shipPosition;

        public PositionClamper(PlayerShip playerShip)
        {
            _shipPosition = playerShip.transform;
        }


        public void ClampPosition()
        {
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(_shipPosition.position);
            Vector3 adjustmentPosition = Vector3.zero;

            if (viewportPosition.x < 0)
                adjustmentPosition.x += 1;

            else if (viewportPosition.x > 1)
                adjustmentPosition.x -= 1;

            else if (viewportPosition.y < 0)
                adjustmentPosition.y += 1;

            else if (viewportPosition.y > 1)
                adjustmentPosition.y -= 1;

            _shipPosition.position = Camera.main.ViewportToWorldPoint(viewportPosition + adjustmentPosition);
        }
    }
}
