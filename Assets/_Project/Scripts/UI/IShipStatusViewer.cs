using UnityEngine;

namespace Suli.Asteroids
{
    public interface IShipStatusViewer
    {
        void SetCoordinates(Vector2 position);
        void SetSpeed(float speed);
        void SetAngle(float angle);
        void SetLaserCooldown(float cooldown);
        void SetLaserCharges(int charges);
    }
}