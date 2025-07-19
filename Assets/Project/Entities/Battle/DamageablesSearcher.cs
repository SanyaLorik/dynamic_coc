using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class DamageablesSearcher : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private TeamType _searchingTeam;

    private readonly HashSet<IDamageable> _damageables = new();

    public IReadOnlyList<DamageableContainer> Damageables
    {
        get
        {
            List<DamageableContainer> result = new();

            Vector3 centerPosition = _center.position;

            foreach (var damageable in _damageables)
            {
                MonoBehaviour damageableMonoBehaviour = damageable as MonoBehaviour;
                if (damageableMonoBehaviour == null)
                    continue;

                Vector3 position = damageableMonoBehaviour.transform.position;
                result.Add(new DamageableContainer(position, damageable));
            }

            result.Sort((a, b) =>
            {
                float sqrDistA = (centerPosition - a.Position).sqrMagnitude;
                float sqrDistB = (centerPosition - b.Position).sqrMagnitude;
                return sqrDistA.CompareTo(sqrDistB);
            });

            return result;
        }
    }

    // Остальные методы остаются без изменений
    private void OnCollisionEnter(Collision collision)
    {
        TryAddDamageable(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        TryRemoveDamageable(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        TryAddDamageable(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        TryRemoveDamageable(other.gameObject);
    }

    private void TryAddDamageable(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IDamageable damageable) == false)
            return;

        if (damageable.Team != _searchingTeam)
            return;

        if (_damageables.Contains(damageable) == false)
            _damageables.Add(damageable);
    }

    private void TryRemoveDamageable(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IDamageable damageable) == false)
            return;

        if (_damageables.Contains(damageable) == true)
            _damageables.Remove(damageable);
    }
}

public readonly struct DamageableContainer
{
    public readonly Vector3 Position;
    public readonly IDamageable Damageable;

    public DamageableContainer(Vector3 position, IDamageable damageable)
    {
        Position = position;
        Damageable = damageable;
    }
}