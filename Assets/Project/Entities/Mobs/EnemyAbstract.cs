using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(Collider))]
public abstract class EnemyAbstract : MonoBehaviour, IDamageable
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Health _health;
    [field: SerializeField] public TeamType Team { get; private set; }

    [Inject] private MobDirector _mobDirector;

    public bool IsAllowDamage => _health.IsAlive;

    public async UniTaskVoid Move()
    {
        do
        {
            MobTarget mobTarget = await _mobDirector.GetMobTarget(transform.position, destroyCancellationToken);
            _agent.SetDestination(mobTarget.Target);
        }
        while (destroyCancellationToken.IsCancellationRequested == false);
    }

    public void Damage(int value)
    {
        if (_health.IsDead == true)
            return;

        _health.Change(value);

        if (_health.IsDead == true)
            DestroySelf();
    }

    private void DestroySelf()
    {
        throw new NotImplementedException();
    }
}
