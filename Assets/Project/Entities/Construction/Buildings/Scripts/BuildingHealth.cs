using System;
using UnityEngine;

public class BuildingHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private BuildingDestruction _destruction;

    [field: SerializeField] public TeamType Team { get; private set; }

    public event Action OnDestroyed;

    public bool IsAllowDamage => _health.IsAlive;

    public void Damage(int value)
    {
        if (!IsAllowDamage) return;

        _health.Reduce(value);

        if (_health.IsDead)
        {
            _destruction.Destroy();
            OnDestroyed?.Invoke();
        }
    }
}
