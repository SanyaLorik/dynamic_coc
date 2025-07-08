using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _image;
    [SerializeField] private float _duration;

    private Tween _tween;

    private void OnEnable()
    {
        _health.OnChanged += OnUpdate;
    }

    private void OnDisable()
    {
        _health.OnChanged -= OnUpdate;
    }

    private void OnUpdate(int value)
    {
        float ratio = (float)_health.MaxHealth / (float)_health.Current;

        _tween?.Kill();
        _tween = _image.DOFillAmount(ratio, _duration);
    }
}