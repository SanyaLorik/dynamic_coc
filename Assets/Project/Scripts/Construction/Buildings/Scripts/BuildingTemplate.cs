using System.Linq; 
using UnityEngine;

public class BuildingTemplate : MonoBehaviour
{
    [field: SerializeField] public BuildingAbstract Building { get; private set; }
    [field: SerializeField] public Vector3 PlacementOffset { get; private set; }
    [field: SerializeField] public Vector3 PlacementSize { get; private set; }

    public bool CanPlace { get; private set; } = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = CanPlace ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position + PlacementOffset, PlacementSize);
    }

    private void Update()
    {
        CanPlace = IsOverlappingWithOtherBuildings() == false;
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
            otherBuilding != Building
        );
    }


    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}