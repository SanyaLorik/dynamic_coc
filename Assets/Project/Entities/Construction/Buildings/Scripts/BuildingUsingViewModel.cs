using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUsingViewModel : MonoBehaviour
{
    [SerializeField] private OpportunityButton[] _opportunitiesButtons;
    [SerializeField] private AnimationAbstract _panelAnimation;

    private Tween _panelTween;

    public void ShowPanel()
    {
        _panelTween?.Kill();
        _panelTween = _panelAnimation.Show();
    }

    public void HidePanel()
    {
        _panelTween?.Kill();
        _panelTween = _panelAnimation
            .Hide()
            .OnComplete(HideButtons);
    }

    public void ShowButtons(BuildingAbstract building)
    {
        IReadOnlyList<BuildingOpportunityAbstract> opportunities = building.GetOpportunities();
        int length = Mathf.Min(_opportunitiesButtons.Length, opportunities.Count);

        for (int i = 0; i < length; i++)
            _opportunitiesButtons[i].Initialize(opportunities[i].Icon, () => opportunities[i].Execute());
    }

    private void HideButtons()
    {
        foreach (var opportunityButton in _opportunitiesButtons)
            opportunityButton.Deinitialize();
    }
}
