using System;
using UnityEngine;

public abstract class BuildingAbstract : MonoBehaviour
{
    [SerializeField] private BuildingHealth _health;
    [SerializeField] private BuildingVisualEffects _visualEffects;
    [SerializeField] private BuildingTargeting _targeting;
    [SerializeField] private BuildingEconomics _economics;
    [SerializeField] private BuildingDestruction _destruction;
    [SerializeField] private BuildingTemplate _template;

    public bool CanPlace => _template.CanPlace;

    public ITargetable Targetable => _targeting;

    public void Awake()
    {
        _template.Initialize(this);
    }

    public void Initialize(EntityCollection collection)
    {
        _destruction.Initialize(collection, this);
        _health.OnDestroyed += OnDestroyedHandler;
    }

    public void Place()
    {
        _visualEffects.PlayPlacementAnimation();
    }

    public void StartPlacing()
    {
        _template.StartPlacing().Forget();   
    }

    public void StopPlacing()
    {
        _template.StopPlacing();
    }

    public void DestroySelf()
    {
        _destruction.Destroy();
    }

    public void DestroySelfInstant()
    {
        _destruction.DestroyInstant();
    }

    private void OnDestroyedHandler()
    {
        DestroySelf();
    }
}