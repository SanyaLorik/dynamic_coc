using UnityEngine;

public abstract class BuildingAbstract : MonoBehaviour
{
    [field: SerializeField] public float Price { get; private set; }

    [SerializeField] private ShakeScaleAnimation _animationPlace;

    public void AnimatePlace()
    {
        _animationPlace.Shake();
    }
}
