using _KotletaGames.Additional_M;
using DG.Tweening;
using UnityEngine;

public class ScaleAnimation : AnimationAbstract
{
    [SerializeField] private Vector3 _from;
    [SerializeField] private Vector3 _to;

    [SerializeField] private bool _isActivityChanged;

    public override Tween Show()
    {
        if (_isActivityChanged == true)
            source.ActiveSelf();

        return Scale(_to, shownDuration);
    }

    public override Tween Hide()
    {
        Tween tween = Scale(_from, hiddenDuration);

        if (_isActivityChanged == true)
            tween.OnComplete(source.DisactiveSelf);

        return tween;
    }

    private Tween Scale(Vector3 scale, float duration)
    {
        return source
            .DOScale(scale, duration)
            .SetEase(ease);
    }
}