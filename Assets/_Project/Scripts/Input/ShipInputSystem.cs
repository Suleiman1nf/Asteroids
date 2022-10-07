using System;
using UnityEngine.InputSystem;

namespace Suli.Asteroids
{
    public class ShipInputSystem : IShipInput
    {
        private readonly PlayerInput _playerInput;
        public event Action OnGunFire;
        public event Action OnUseLaser;
        public event Action<bool> OnMove;

        public float Rotation()
        {
            return _playerInput.Player.Rotation.ReadValue<float>();   
        }

        public ShipInputSystem()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            _playerInput.Gun.Shoot.performed += GunFire;
            _playerInput.Laser.Apply.performed += LaserApply;
            _playerInput.Player.Move.performed += MoveHold;
            _playerInput.Player.Move.canceled += MoveRelease;
        }
        
        private void GunFire(InputAction.CallbackContext context)
        {
            OnGunFire?.Invoke();
        }

        private void LaserApply(InputAction.CallbackContext context)
        {
            OnUseLaser?.Invoke();      
        }

        private void MoveHold(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(true);
        }

        private void MoveRelease(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(false);
        }

        ~ShipInputSystem()
        {
            _playerInput.Gun.Shoot.performed -= GunFire;
            _playerInput.Laser.Apply.performed -= LaserApply;
            _playerInput.Player.Move.performed -= MoveHold;
            _playerInput.Player.Move.canceled -= MoveRelease;
        }
    }
}