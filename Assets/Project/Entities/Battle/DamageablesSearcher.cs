using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class DamageablesSearcher : MonoBehaviour
{
    private readonly HashSet<IDamageable> _damageables = new();
    private readonly HashSet<IDamageable> _exceptions = new();
    private readonly List<DamageableContainer> _resultContainers = new();

    public IReadOnlyList<DamageableContainer> DamageablesWithoutExceptions
    {
        get
        {
            _resultContainers.Clear();

            foreach (var damageable in _damageables)
            {
                if (damageable != null && _exceptions.Contains(damageable) == false)
                {
                    MonoBehaviour damageableMonoBehaviour = damageable as MonoBehaviour;
                    if (damageableMonoBehaviour == null)
                        continue;

                    Vector3 position = damageableMonoBehaviour.transform.position;
                    _resultContainers.Add(new DamageableContainer(position, damageable));
                }
            }

            return _resultContainers;

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

    public void AddException(IDamageable damageable)
    {
        _exceptions.Add(damageable);
    }

    public void RemoveException(IDamageable damageable)
    {
        _exceptions.Remove(damageable);
    }

    public void ClearExceptions()
    {
        _exceptions.Clear();
    }

    private void TryAddDamageable(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IDamageable damageable))
        {
            _damageables.Add(damageable);
        }
    }

    private void TryRemoveDamageable(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IDamageable damageable))
        {
            _damageables.Remove(damageable);
        }
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