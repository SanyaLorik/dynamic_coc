using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IInputService
{
    Vector3 DirectionMovement { get; }

    void Enable();

    void Disable();
}

public class StateSwitcher : IStateSwitcher
{
    private readonly IReadOnlyList<IState> _states;
    private IState _currentState;

    public StateSwitcher(IReadOnlyList<IState> states)
    {
        _states = states;
        _currentState = _states[0];
    }

    public void Switch<T>() where T : IState
    {
        _currentState.DisableState();
        _currentState = _states.FirstOrDefault(i => i.GetType() == typeof(T));
        _currentState.EnableState();
    }
}

public interface IStateSwitcher
{
    void Switch<T>()
        where T : IState;
}

public interface IState
{
    void EnableState();

    void DisableState();
}