using System;
using UnityEngine;

public class CustomJoystick : MonoBehaviour
{
    private FloatingJoystick _floatingJoystick;

    private void Awake()
    {
        _floatingJoystick = GetComponent<FloatingJoystick>();
    }

    public void Enable()
    {
        _floatingJoystick.enabled = true;
    }
    
    public void Disable()
    {
        _floatingJoystick.enabled = false;        
    }
}
