using Input;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerInputRouter
    {
        private readonly CustomJoystick _joystick;
        private readonly PlayerMove _playerMove;
        private readonly PlayerGunRotater _playerGunRotater;
        private readonly PlayerShoot _playerShoot;
        private readonly ShootButton _shootButton;
        private bool _isJoystickMoved;
        private Vector2 _deltaVector2;
        private Player _player;


        public PlayerInputRouter(CustomJoystick joystick, Player player, ShootButton shootButton)
        {
            _player = player;
            _joystick = joystick;
            _playerMove = player.PlayerMove;
            _playerGunRotater = player.PlayerGunRotater;
            _playerShoot = player.PlayerShoot;
            _shootButton = shootButton;
        }

        public void OnEnable()
        {
            _joystick.Enable();
            _joystick.OnJoystickTouchStarted += OnJoysitckTouchStarted;
            _joystick.OnJoystickTouchEnded += OnJoysitckTouchEnded;
            _shootButton.OnShootButtonClicked += OnShootButtonClicked;
        }
    
        public void OnDisable()
        {
            _joystick.Enable();
            _joystick.OnJoystickTouchStarted += OnJoysitckTouchStarted;
            _joystick.OnJoystickTouchEnded += OnJoysitckTouchEnded;
            _shootButton.OnShootButtonClicked -= OnShootButtonClicked;
        }

        public void Update(float deltaTime)
        {
            if(!_player)
                return;
            
            if (_isJoystickMoved)
            {
                _deltaVector2 = new Vector2(_joystick.Horizontal, _joystick.Vertical);
                _playerMove.Move(_deltaVector2, deltaTime);
            }
            
            _playerGunRotater.Rotate(_deltaVector2);
        }

        private void OnShootButtonClicked() => 
            _playerShoot.Shoot();

        private void OnJoysitckTouchStarted() => 
            _isJoystickMoved = true;

        private void OnJoysitckTouchEnded() => 
            _isJoystickMoved = false;
    }
}