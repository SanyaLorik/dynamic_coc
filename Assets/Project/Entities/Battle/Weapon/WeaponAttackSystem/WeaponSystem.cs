using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private DamageablesSearcher _damageablesSearcher;
    [SerializeField] private Weapon _weapon;

    private WeaponAttackScheduler _attackScheduler;

    private void Awake()
    {
        _attackScheduler = new(Attack, HasTarget, _weapon.DelayAttacking);    
    }

    private void OnEnable()
    {
        _attackScheduler.Start().Forget();
    }

    private void OnDisable()
    {
        _attackScheduler.Stop();
    }

    private void Attack()
    {
        IReadOnlyList<DamageableContainer> damageables = _damageablesSearcher.Damageables;
        int count = Math.Clamp(damageables.Count, 0, _weapon.CountTarget);

        for (int i = 0; i < count; i++)
            _weapon.Shoot(damageables[i].Position);
    }

    private bool HasTarget()
    {
        return _damageablesSearcher.Damageables.Count > 0;
    }
}