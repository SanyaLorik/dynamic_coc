using System;
using UnityEngine;

[Serializable]
public class InputJoystick : IInputService
{
    [SerializeField] private Joystick _joystick;

    public Vector3 DirectionMovement
    {
        get => new()
        {
            x = _joystick.Direction.x,
            z = _joystick.Direction.y
        };
    }
}
