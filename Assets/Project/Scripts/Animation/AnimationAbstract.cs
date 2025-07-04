using DG.Tweening;
using UnityEngine;

public abstract class AnimationAbstract : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] protected Transform source;
    [SerializeField] [Min(0)] protected float shownDuration;
    [SerializeField] [Min(0)] protected float hiddenDuration;
    [SerializeField] protected Ease ease;

    public abstract Tween Show();

    public abstract Tween Hide();
}
