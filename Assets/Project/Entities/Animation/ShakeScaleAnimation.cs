using DG.Tweening;
using UnityEngine;

public class ShakeScaleAnimation : ScaleAnimation
{
    [Header("Shake")]
    [SerializeField] private float _strenght;
    [SerializeField] private float _duration;
    [SerializeField] private int _vibrato;
    [SerializeField] private Ease _ease;

    public void Shake()
    {
        source
            .DOShakeScale(_duration, _strenght, _vibrato)
            .SetEase(_ease);
    }
}