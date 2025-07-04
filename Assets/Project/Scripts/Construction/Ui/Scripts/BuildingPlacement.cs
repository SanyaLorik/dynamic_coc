using _KotletaGames.Additional_M;
using System;
using UnityEngine;

[Serializable]
public class BuildingPlacement
{
    [SerializeField] private BuildingButton[] _buildingButtons;
    [SerializeField] private PositionSpawner _spawner;
    [SerializeField] private PointerDragOnGround _pointerDragOnGround;

    private BuildingTemplate _buildingTemplate;

    public void Init()
    {
        _pointerDragOnGround.ActiveSelf();

        _pointerDragOnGround.OnDragPositionChanged += OnSetPosition;
        _buildingButtons.ForEach(i => i.Button.onClick.AddListener(() => Instantiate(i.Template)));
    }

    public void Deinit()
    {
        _pointerDragOnGround.DisactiveSelf();
        DestroyPrevious();

        _buildingButtons.ForEach(i => i.Button.onClick.RemoveAllListeners());
        _pointerDragOnGround.OnDragPositionChanged -= OnSetPosition;
    }

    public void Place()
    {
        if (_buildingTemplate == null)
            return;

        if (_buildingTemplate.CanPlace == false)
        {
            Debug.Log("Пересекает!");
            return;
        }

        BuildingAbstract build = _spawner.Spawn(_buildingTemplate.Building, _buildingTemplate.transform.position);
        build.AnimatePlace();

        DestroyPrevious();
    }

    private void OnSetPosition(Vector3 position)
    {
        if (_buildingTemplate == null)
            return;

        _buildingTemplate.transform.position = position;
    }

    private void Instantiate(BuildingTemplate buildingTemplate)
    {
        DestroyPrevious();
        _buildingTemplate = _spawner.Spawn(buildingTemplate, Vector3.zero);
    }

    private void DestroyPrevious()
    {
        if (_buildingTemplate != null)
            _buildingTemplate.DestroySelf();
    }
}
