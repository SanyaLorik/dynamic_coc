using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _offset = 1;

    [Inject] private MobDirector _mobDirector;

    public bool IsArrived => _agent.remainingDistance > _agent.stoppingDistance;

    public async UniTask StartMoving()
    {
        while (destroyCancellationToken.IsCancellationRequested == false)
        {
            MobTarget target = await _mobDirector.GetMobTarget(transform.position, destroyCancellationToken);

            Vector3 position = target.Target + (target.Target - _agent.transform.position).normalized * _offset;
            _agent.SetDestination(position);

            await UniTask.WaitWhile(() => IsArrived, cancellationToken: destroyCancellationToken);
        }
    }
}
