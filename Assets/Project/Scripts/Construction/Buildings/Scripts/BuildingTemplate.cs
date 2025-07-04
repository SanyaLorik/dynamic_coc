using UnityEngine;

public class BuildingTemplate : MonoBehaviour
{
    [field: SerializeField] public BuildingBase Building { get; private set; }
    [field: SerializeField] public float PlacementRadius { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, PlacementRadius);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

