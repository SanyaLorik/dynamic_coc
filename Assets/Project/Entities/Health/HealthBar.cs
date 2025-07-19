using _KotletaGames.Additional_M;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _image;
    [SerializeField] private float _duration;

    [SerializeField] private GameObject _healthContainer;
    [SerializeField] private bool _isHideFullHealth;

    private Tween _tween;

    private void Awake()
    {
        ControlActivityByFlag();
    }

    private void Start()
    {
        OnUpdate(_health.Current);
    }

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
        ControlActivityByFlag();

        float ratio = (float)value / (float)_health.MaxHealth;

        _tween?.Kill();
        _tween = _image.DOFillAmount(ratio, _duration);
    }

    private void ControlActivityByFlag()
    {
        if (_isHideFullHealth == false)
            return;

        if (_health.Full == true)
            _healthContainer.DisactiveSelf();
        else
            _healthContainer.ActiveSelf();
    }
}