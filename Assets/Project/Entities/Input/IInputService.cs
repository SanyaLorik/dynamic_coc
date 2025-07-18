using UnityEngine;

public interface IInputService
{
    Vector3 DirectionMovement { get; }

    void Enable();

    void Disable();
}