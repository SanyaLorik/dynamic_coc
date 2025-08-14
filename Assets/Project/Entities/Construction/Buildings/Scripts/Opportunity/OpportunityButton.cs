using System;
using UnityEngine;
using UnityEngine.UI;

public class OpportunityButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;

    public void Initialize(Sprite icon, Action value)
    {
        _icon.sprite = icon;
        _button.onClick.AddListener(value.Invoke);
    }

    public void Deinitialize()
    {
        _button.onClick.RemoveAllListeners();
    }
}