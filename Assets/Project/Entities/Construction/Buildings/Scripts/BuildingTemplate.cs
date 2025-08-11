using Cysharp.Threading.Tasks;
using System.Linq;
using System.Threading;
using UnityEngine;

public class BuildingTemplate : MonoBehaviour
{
    [field: SerializeField] public Vector3 PlacementOffset { get; private set; }
    [field: SerializeField] public Vector3 PlacementSize { get; private set; }

    private BuildingAbstract _selfBuilding;
    private CancellationTokenSource _tokenSource;

    public bool CanPlace { get; private set; } = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = CanPlace ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + PlacementOffset, PlacementSize);
    }

    private void OnDestroy()
    {
        _tokenSource?.Cancel();
        _tokenSource?.Dispose();
    }

    public void Initialize(BuildingAbstract selfBuilding)
    {
        _selfBuilding = selfBuilding;
    }

    public async UniTaskVoid StartPlacing()
    {
        _tokenSource = new();

        while (_tokenSource.IsCancellationRequested == false)
        {
            await UniTask.Yield(cancellationToken: _tokenSource.Token);

            CanPlace = IsOverlappingWithOtherBuildings() == false;
        }
    }

    public void StopPlacing()
    {
        _tokenSource?.Cancel();
    }

    public bool IsOverlappingWithOtherBuildings()
    {
        Collider[] hitColliders = Physics.OverlapBox(
            transform.position + PlacementOffset,
            PlacementSize * 0.5f,
            transform.rotation
        );

        return hitColliders.Any(collider =>
           collider.TryGetComponent(out BuildingAbstract otherBuilding) &&
           otherBuilding != _selfBuilding
       );
    }
}