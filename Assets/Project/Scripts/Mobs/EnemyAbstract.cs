using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAbstract : MonoBehaviour, IDamageable
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Health _health;

    public bool IsAllowDamage { get; private set; } = true;

    public void MoveTo(Vector3 target)
    {
        _agent.Move(target);
    }

    public void Damage(int value)
    {
        if (_health.Current == 0)
            return;

        _health.Change(value);

        IsAllowDamage = _health.Current > 0;

        if (_health.Current == 0)
            DestroySelf();
    }

    private void DestroySelf()
    {
        throw new NotImplementedException();
    }
}
