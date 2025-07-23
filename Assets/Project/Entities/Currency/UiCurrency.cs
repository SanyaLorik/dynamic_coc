using TMPro;
using UnityEngine;
using Zenject;

public class UiCurrency : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCountText;
    [SerializeField] private TextMeshProUGUI _gemsCountText;

    [Inject] private Currency _currency;

    private void Start()
    {
        OnSetCoinsText(_currency.Coins.Count);
        OnSetGemsText(_currency.Gems.Count);
    }

    private void OnEnable()
    {
        _currency.Coins.OnChanged += OnSetCoinsText;
        _currency.Gems.OnChanged += OnSetGemsText;
    }

    private void OnDisable()
    {
        _currency.Coins.OnChanged -= OnSetCoinsText;
        _currency.Gems.OnChanged -= OnSetGemsText;
    }

    private void OnSetCoinsText(long value)
    {
        _coinsCountText.text = value.ToString();
    }

    private void OnSetGemsText(long value)
    {
        _gemsCountText.text = value.ToString();
    }
}