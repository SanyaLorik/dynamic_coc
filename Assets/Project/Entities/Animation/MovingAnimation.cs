using DG.Tweening;
using UnityEngine;

public class MovingAnimation : AnimationAbstract
{
    [SerializeField] private Transform _from;
    [SerializeField] private Transform _to;

    public override Tween Show()
    {
        return Move(_to.position, shownDuration);
    }

    public override Tween Hide()
    {
        return Move(_from.position, hiddenDuration);
    }

    private Tween Move(Vector3 position, float duration)
    {
        return source
            .DOMove(position, duration)
            .SetEase(ease);
    }
}