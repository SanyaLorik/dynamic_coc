using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private MissileSystem _missileSystem;
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackCooldown = 1f;

    [Inject] private MobDirector _mobDirector;

    public async UniTaskVoid StartAttacking()
    {
        while (destroyCancellationToken.IsCancellationRequested == false)
        {
            MobTarget target = await _mobDirector.GetMobTarget(transform.position, destroyCancellationToken);
            await UniTask.WaitWhile(() => (target.Target - _center.position).sqrMagnitude > _attackRange * _attackRange);

            _missileSystem.Launch(target.Target).Forget();

            await UniTask.Delay(TimeSpan.FromSeconds(_attackCooldown));
        }
    }
}
