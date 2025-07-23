using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class EnemyAbstract : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private EnemyHealth _health;

    private void Start()
    {
        _movement.StartMoving().Forget();
    }
}
