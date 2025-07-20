using ModestTree;
using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealthWatcher
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int Current { get; private set; }

    public bool IsAlive => Current > 0;

    public bool Full => MaxHealth == Current;

    public bool IsDead => Current == 0;

    public event Action<int> OnChanged;

    private void Awake()
    {
        Current = MaxHealth;
    }

    public void Add(int value)
    {
        Change(value);
    }

    public void Reduce(int value)
    {
        Change(-value);
    }

    private void Change(int value)
    {
        Current = Mathf.Clamp(Current + value, 0, MaxHealth);
        OnChanged?.Invoke(Current);
    }
}
