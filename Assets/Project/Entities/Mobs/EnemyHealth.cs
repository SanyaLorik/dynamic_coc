using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyReward _reward;

    [field: SerializeField] public TeamType Team { get; private set; }

    public bool IsAllowDamage => _health.IsAlive;

    public void Damage(int value)
    {
        if (_health.IsDead == true)
            return;

        _health.Reduce(value);

        if (_health.IsDead == true)
            DestroySelf();
    }

    private void DestroySelf()
    {
        _reward.GiveReward();

        Destroy(gameObject);
    }
}
