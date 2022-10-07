using System;
using TMPro;
using UnityEngine;

namespace Suli.Asteroids
{
    public class StatusPanelUI : MonoBehaviour, IShipStatusViewer
    {
        [SerializeField] private TMP_Text positionTMPText;
        [SerializeField] private TMP_Text speedTMPText;
        [SerializeField] private TMP_Text angleTMPText;
        [SerializeField] private TMP_Text laserChargesTMPText;
        [SerializeField] private TMP_Text laserCooldownTMPText;

        private const string SpeedLocalization = "Speed:";
        private const string AngleLocalization = "Angle:";
        private const string LaserChargesLocalization = "Laser charges:";
        private const string ChargesCooldownLocalization = "Charges cooldown:";

        public void SetCoordinates(Vector2 position)
        {
            positionTMPText.SetText($"x:{position.x:0.0} y: {position.y:0.0}");
        }

        public void SetSpeed(float speed)
        {
            speedTMPText.SetText($"{SpeedLocalization} {speed:00.0}");
        }

        public void SetAngle(float angle)
        {
            angleTMPText.SetText($"{AngleLocalization} {angle:000}");
        }
        
        public void SetLaserCooldown(float cooldown)
        {
            laserCooldownTMPText.SetText($"{ChargesCooldownLocalization} {cooldown:0.0}");
        }
        
        public void SetLaserCharges(int charges)
        {
            laserChargesTMPText.SetText($"{LaserChargesLocalization} {charges}");
        }
    }
}