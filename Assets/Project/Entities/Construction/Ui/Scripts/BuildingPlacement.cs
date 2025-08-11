using _KotletaGames.Additional_M;
using UnityEngine;
using Zenject;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField] private BuildingButton[] _buildingButtons;
    [SerializeField] private PositionSpawner _spawner;
    [SerializeField] private PointerDragOnGround _pointerDragOnGround;

    [Inject] private EntityCollection _entityCollection;

    private BuildingAbstract _buildingPattern;

    public void Init()
    {
        _pointerDragOnGround.ActiveSelf();

        _pointerDragOnGround.OnDragPositionChanged += OnSetPosition;
        _buildingButtons.ForEach(i => i.Button.onClick.AddListener(() => InstantiateBuilding(i.BuildingPrefab)));
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
        if (_buildingPattern == null)
            return;

        if (_buildingPattern.CanPlace == false)
        {
            Debug.Log("Пересекает!");
            return;
        }

        BuildingAbstract build = _spawner.Spawn(_buildingPattern, _buildingPattern.transform.position);
        build.Initialize(_entityCollection);
        build.Place();

        _entityCollection.AddBuilding(build);

        DestroyPrevious();
    }

    private void OnSetPosition(Vector3 position)
    {
        if (_buildingPattern == null)
            return;

        _buildingPattern.transform.position = position;
    }

    private void InstantiateBuilding(BuildingAbstract buildingPrefab)
    {
        DestroyPrevious();

        _buildingPattern = _spawner.Spawn(buildingPrefab, Vector3.zero);
        _buildingPattern.StartPlacing();
    }

    private void DestroyPrevious()
    {
        if (_buildingPattern == null)
            return;

        _buildingPattern.StopPlacing();
        _buildingPattern.DestroySelfInstant();

        _buildingPattern = null;
    }
}
