using System;
using UnityEngine;
using UnityEngine.Assertions;

[Serializable]
public class Wallet
{
    [field: SerializeField] public long Count {  get; private set; }

    public event Action<long> OnChanged;

    public bool CanReduce(long value)
    {
        return Count - value >= 0;
    }

    public void Add(long value)
    {
        Assert.IsFalse(value < 0, "Value is not less then zero!");

        Change(value);
    }

    public void Reduce(long value)
    {
        Assert.IsFalse(value < 0, "Value is not less then zero!");
        Assert.IsFalse(Count - value < 0, "(Count - value) is not less then zero!");

        Change(-value);
    }

    private void Change(long value)
    {
        Count = Math.Clamp(Count + value, 0, long.MaxValue);

        OnChanged?.Invoke(Count);
    }
}
