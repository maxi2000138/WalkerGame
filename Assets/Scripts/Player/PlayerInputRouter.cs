using Zenject;

public class PlayerInputRouter
{
    private CustomJoystick _joystick;
    private Player _player;

    [Inject]
    public void Construct(CustomJoystick joystick)
    {
        _joystick = joystick;
    }

    public void OnEnable()
    {
        _joystick.Enable();
    }
    
    public void OnDisable()
    {
        _joystick.Disable();
    }

    public void Update()
    {
        
    }
    
}

public class Player
{
    
}

