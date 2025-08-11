using UnityEngine;

public class BuildingDestruction : MonoBehaviour
{
    private EntityCollection _entityCollection;
    private BuildingAbstract _building;

    public void Initialize(EntityCollection collection, BuildingAbstract building)
    {
        _entityCollection = collection;
        _building = building;
    }

    public void Destroy()
    {
        _entityCollection.RemoveBuilding(_building);
        Destroy(gameObject);
    }

    public void DestroyInstant()
    {
        Destroy(gameObject);
    }
}
