using UnityEngine;
using Zenject;

public class EntityCollectionInstaller : MonoInstaller
{
    [SerializeField] private BuildingAbstract[] _initialBuildings;

    public override void InstallBindings()
    {
        EntityCollection entityCollection = new();

        foreach (var building in _initialBuildings)
            entityCollection.AddBuilding(building);

        Container
            .BindInterfacesAndSelfTo<EntityCollection>()
            .FromInstance(entityCollection)
            .AsCached();
    }
}