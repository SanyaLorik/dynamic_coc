using System;
using UnityEngine;
using UnityEngine.Assertions;

public class Wallet : MonoBehaviour
{
    [field: SerializeField] public long Count {  get; private set; }

    public event Action<long> OnChanged;

    public bool CanReduce(long value)
    {
        return Count - value >= 0;
    }

    public void Add(long value)
    {
        Assert.IsTrue(value < 0, "Value is not less then zero!");

        Change(value);
    }

    public void Reduce(long value)
    {
        Assert.IsTrue(value < 0, "Value is not less then zero!");
        Assert.IsTrue(Count - value < 0, "(Count - value) is not less then zero!");

        Change(-value);
    }

    private void Change(long value)
    {
        Count = Math.Clamp(Count + value, 0, long.MaxValue);

        OnChanged?.Invoke(Count);
    }
}