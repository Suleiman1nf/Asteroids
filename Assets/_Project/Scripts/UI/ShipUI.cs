namespace Suli.Asteroids
{
    public class ShipUI
    {
        private readonly IShipStatusViewer _ui;
        private readonly IShipStatusProvider _shipStatus;
        
        public ShipUI(IShipStatusProvider shipStatusStatus, IShipStatusViewer ui)
        {
            _shipStatus = shipStatusStatus;
            _ui = ui;
            shipStatusStatus.OnChargesCountChanged += OnChargesCountChanged;
            OnChargesCountChanged(_shipStatus.ChargesCount);
        }
        
        ~ShipUI()
        {
            _shipStatus.OnChargesCountChanged -= OnChargesCountChanged;
        }

        public void Update(float dt)
        {
            _ui.SetCoordinates(_shipStatus.Position);
            _ui.SetSpeed(_shipStatus.Speed);
            _ui.SetAngle(_shipStatus.Angle);
            _ui.SetLaserCooldown(_shipStatus.ChargesCooldown);
        }

        private void OnChargesCountChanged(int value)
        {
            _ui.SetLaserCharges(value);
        }
    }
}