using UnityEngine;
using UnityEngine.UI;

public class BuildingUsing : MonoBehaviour
{
    [SerializeField] private PointerClickBuildHandler _pointerClick;
    [SerializeField] private BuildingUsingViewModel _buildingUsingViewModel;
    [SerializeField] private Button _backButton;

    private void OnEnable()
    {
        _pointerClick.OnTargetClicked += OnClickOnBuild;
        _backButton.onClick.AddListener(OnBack);
    }

    private void OnDisable()
    {
        _pointerClick.OnTargetClicked -= OnClickOnBuild;
        _backButton.onClick.RemoveListener(OnBack);
    }

    private void OnClickOnBuild(BuildingAbstract building)
    {
        _buildingUsingViewModel.ShowPanel();
        _buildingUsingViewModel.ShowButtons(building);
    }

    private void OnBack()
    {
        _buildingUsingViewModel.HidePanel();
    }
}
