using _KotletaGames.Additional_M;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ViewModelConstruction : MonoBehaviour
{
    [SerializeField] private AnimationConstruction _animation;
    [SerializeField] private BuildingPlacement _buildingPlacement;
    [SerializeField] private Button _startBuildings;
    [SerializeField] private Button _stopBuildings;

    [Inject] private IInputService _inputService;

    private void OnEnable()
    {
        _startBuildings.onClick.AddListener(OnStartBuilding);
        _stopBuildings.onClick.AddListener(OnStopBuilding);
    }

    private void OnDisable()
    {
        _startBuildings.onClick.RemoveListener(OnStartBuilding);
        _stopBuildings.onClick.RemoveListener(OnStopBuilding);
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
}
