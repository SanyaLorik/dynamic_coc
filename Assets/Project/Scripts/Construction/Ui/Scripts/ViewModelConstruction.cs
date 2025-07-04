using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ViewModelConstruction : MonoBehaviour
{
    [SerializeField] private AnimationConstruction _animation;
    [SerializeField] private BuildingPlacement _buildingPlacement;
    [SerializeField] private Button _startBuildings;
    [SerializeField] private Button _stopBuildings;
    [SerializeField] private Button _placeBuildings;

    [Inject] private IInputService _inputService;

    private void OnEnable()
    {
        _startBuildings.onClick.AddListener(OnStartBuilding);
        _stopBuildings.onClick.AddListener(OnStopBuilding);
        _placeBuildings.onClick.AddListener(OnPlaceBuilding);
    }

    private void OnDisable()
    {
        _startBuildings.onClick.RemoveListener(OnStartBuilding);
        _stopBuildings.onClick.RemoveListener(OnStopBuilding);
        _placeBuildings.onClick.RemoveListener(OnPlaceBuilding);
    }

    private void OnStartBuilding()
    {
        _animation.Show().Forget();
        _inputService.Disable();
        _buildingPlacement.Init();
    }

    private void OnStopBuilding()
    {
        _animation.Hide().Forget();
        _inputService.Enable();
        _buildingPlacement.Deinit();
    }

    private void OnPlaceBuilding()
    {
        _buildingPlacement.Place();
    }
}
