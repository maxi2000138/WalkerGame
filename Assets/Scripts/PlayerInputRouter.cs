using UnityEngine;

public class PlayerInputRouter
{
    private readonly CustomJoystick _joystick;
    private readonly PlayerMove _playerMove;
    private readonly PlayerGunRotater _playerGunRotater;
    private readonly PlayerShoot _playerShoot;
    private readonly ShootButton _shootButton;
    private bool _isJoystickMoved;
    

    public PlayerInputRouter(CustomJoystick joystick, PlayerMove playerMove, PlayerGunRotater playerGunRotater, 
        PlayerShoot playerShoot, ShootButton shootButton)
    {
        _joystick = joystick;
        _playerMove = playerMove;
        _playerGunRotater = playerGunRotater;
        _playerShoot = playerShoot;
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
        if (_isJoystickMoved)
        {
            Vector2 deltaVector2 = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            _playerMove.Move(deltaVector2, deltaTime);
            _playerGunRotater.Rotate(deltaVector2);
        }
    }

    private void OnShootButtonClicked() => 
        _playerShoot.Shoot();

    private void OnJoysitckTouchStarted() => 
        _isJoystickMoved = true;

    private void OnJoysitckTouchEnded() => 
        _isJoystickMoved = false;
}