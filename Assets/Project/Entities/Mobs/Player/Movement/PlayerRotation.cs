using UnityEngine;
using Zenject;

public class PlayerRotation : IFixedTickable
{
    private readonly Rigidbody _rigidbody;

    // Injects
    private readonly GameConfig _config;
    private readonly IInputService _input;

    public PlayerRotation(Rigidbody rigidbody, GameConfig config, IInputService input)
    {
        _rigidbody = rigidbody;
        _config = config;
        _input = input;
    }

    public void FixedTick()
    {
        if (_input.DirectionMovement == Vector3.zero)
            return;

        Vector3 moveDirection = _input.DirectionMovement.normalized;
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

        Quaternion rotation = Quaternion.Slerp(
            _rigidbody.rotation,
            targetRotation,
            _config.PlayerRotationSpeed * Time.fixedDeltaTime
        );

        _rigidbody.MoveRotation(rotation);
    }
}