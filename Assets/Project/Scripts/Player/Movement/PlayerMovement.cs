using UnityEngine;
using Zenject;

public class PlayerMovement : IFixedTickable
{
    private readonly Rigidbody _rigidbody;

    // Injects
    private readonly GameConfig _config;
    private readonly IInputService _input;

    public PlayerMovement(Rigidbody rigidbody, GameConfig config, IInputService input)
    {
        _rigidbody = rigidbody;
        _config = config;
        _input = input;
    }

    public void FixedTick()
    {
        if (_input.DirectionMovement == Vector3.zero)
            return;

        _rigidbody.linearVelocity = _input.DirectionMovement * _config.PlayerMovementSpeed;
    }
}