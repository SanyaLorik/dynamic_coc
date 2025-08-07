using UnityEngine;

public abstract class BuildingAbstract : MonoBehaviour
{
    [SerializeField] private BuildingHealth _health;
    [SerializeField] private BuildingVisualEffects _visualEffects;
    [SerializeField] private BuildingTargeting _targeting;
    [SerializeField] private BuildingEconomics _economics;
    [SerializeField] private BuildingDestruction _destruction;

    public void Initialize(EntityCollection collection)
    {
        _destruction.Initialize(collection, this);
        _health.OnDestroyed += OnDestroyedHandler;
    }

    private void OnDestroyedHandler()
    {
        // Логика при уничтожении
    }

    public void Place()
    {
        _visualEffects.PlayPlacementAnimation();
    }
}
