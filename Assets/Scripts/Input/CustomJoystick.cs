using System;
using UnityEngine.EventSystems;

namespace Input
{
    public class CustomJoystick : FloatingJoystick
    {
        public event Action OnJoystickTouchStarted; 
        public event Action OnJoystickTouchEnded;

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            OnJoystickTouchStarted?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            OnJoystickTouchEnded?.Invoke();
        }

        public void Enable()
        {
            enabled = true;
        }
    
        public void Disable()
        {
            enabled = false;        
        }
    
    
    }
}
