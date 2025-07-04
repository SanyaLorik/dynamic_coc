using _KotletaGames.Additional_M;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ViewModelConstruction : MonoBehaviour
{
    [SerializeField] private AnimationConstruction _animation;
    [SerializeField] private Button _startBuildings;
    [SerializeField] private Button _stopBuildings;
    [SerializeField] private PointerDragOnGround _pointerDragOnGround;

    [Inject] private IInputService _inputService;

    private void OnEnable()
    {
        _startBuildings.onClick.AddListener(OnStartBuilding);
        _stopBuildings.onClick.AddListener(OnStopBuilding);

        _pointerDragOnGround.OnDragPositionChanged += OnChangePosition;
    }

    private void OnDisable()
    {
        _startBuildings.onClick.RemoveListener(OnStartBuilding);
        _stopBuildings.onClick.RemoveListener(OnStopBuilding);

        _pointerDragOnGround.OnDragPositionChanged -= OnChangePosition;
    }

    private void OnStartBuilding()
    {
        _animation.Show().Forget();
        _inputService.Disable();
        _pointerDragOnGround.ActiveSelf();
    }

    private void OnStopBuilding()
    {
        _animation.Hide().Forget();
        _inputService.Enable();
        _pointerDragOnGround.DisactiveSelf();
    }

    private void OnChangePosition(Vector3 position)
    {

    }
}
