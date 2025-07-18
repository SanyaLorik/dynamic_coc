using UnityEngine;

public class MissileDamageExplotion : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _radius;

    public void Explote()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable damageable) == false)
                continue;

            if (damageable.IsAllowDamage == false) 
                continue;

            damageable.Damage(_damage);
        }
    }
}
