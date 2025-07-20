using UnityEngine;

public class MissileDamageExplotion : MonoBehaviour
{
    [SerializeField] private TeamType _damageTeam;
    [SerializeField] private int _damage;
    [SerializeField] private int _radius;

    public void Explote()
    {
        // Включаем обнаружение триггеров (QueryTriggerInteraction.Collide)
        Collider[] colliders = Physics.OverlapSphere(
            transform.position,
            _radius,
            -1, // Все слои
            QueryTriggerInteraction.Collide
        );

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable damageable) == false)
                continue;

            if (damageable.IsAllowDamage == false) 
                continue;

            if (damageable.Team != _damageTeam)
                continue;

            damageable.Damage(_damage);
        }
    }
}
