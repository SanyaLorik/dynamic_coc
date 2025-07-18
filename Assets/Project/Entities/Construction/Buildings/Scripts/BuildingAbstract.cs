using UnityEngine;

public abstract class BuildingAbstract : MonoBehaviour, IDamageable, ITargetable
{
    [SerializeField] private Health _health;
    [SerializeField] private ShakeScaleAnimation _animationPlace;

    [field: SerializeField] public Transform Center { get; private set; }
    [field: SerializeField] public float OffsetByCenter { get; private set; }
    [field: SerializeField] public float Price { get; private set; }

    public bool IsAllowDamage => _health.IsAlive;

    public IHealthWatcher HealthWatcher => _health;

    public Vector3 Position => Center == null ? Vector3.zero : Center.position;

    private EntityCollection _entityCollection;

    public void Init(EntityCollection entityCollection)
    {
        _entityCollection = entityCollection;   
    }

    public void AnimatePlace()
    {
        _animationPlace.Shake();
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
        _entityCollection.RemoveBuilding(this);
    }
}
