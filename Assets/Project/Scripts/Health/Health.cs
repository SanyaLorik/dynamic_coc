using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int Current { get; private set; }

    public event Action<int> OnChanged;

    private void Awake()
    {
        Current = MaxHealth;
    }

    public void Change(int value)
    {
        Current = Mathf.Clamp(Current + value, 0, MaxHealth);

        OnChanged?.Invoke(Current);
    }
}