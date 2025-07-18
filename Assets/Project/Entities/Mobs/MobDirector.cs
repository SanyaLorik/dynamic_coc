using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class MobDirector
{
    private readonly EntityCollection _entityCollection;

    public MobDirector(EntityCollection entityCollection)
    {
        _entityCollection = entityCollection;
    }

    public async UniTask<MobTarget> GetMobTarget(Vector3 mobPosition, CancellationToken token)
    {
        await UniTask.WaitWhile(() => _entityCollection.HasAlliances == false, cancellationToken: token);

        ITargetable closest = null;
        float minDistance = Mathf.Infinity;

        foreach (var alliance in _entityCollection.AllianceTargets)
        {
            if (alliance == null)
                continue;

            float distance = Vector3.Distance(mobPosition, alliance.Position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = alliance;
            }
        }

        Vector3 position = closest.Position - (closest.Position - mobPosition).normalized * closest.OffsetByCenter;
        MobTarget mobTarget = new(position);

        return mobTarget;
    }
}
