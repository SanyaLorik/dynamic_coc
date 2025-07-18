using _KotletaGames.Additional_M;
using DG.Tweening;
using UnityEngine;

public class ScaleAnimation : AnimationAbstract
{
    [Header("Scale")]
    [SerializeField] private Vector3 _from;
    [SerializeField] private Vector3 _to;

    [SerializeField] private bool _isActivityChanged;

    public override Tween Show()
    {
        if (_isActivityChanged == true)
            source.ActiveSelf();

        return Scale(_to, _from, shownDuration);
    }

    public override Tween Hide()
    {
        Tween tween = Scale(_from, _to, hiddenDuration);

        if (_isActivityChanged == true)
            tween.OnComplete(source.DisactiveSelf);

        return tween;
    }

    private Tween Scale(Vector3 scale, Vector3 initial, float duration)
    {
        source.localScale = initial;

        return source
            .DOScale(scale, duration)
            .SetEase(ease);
    }
}