using UnityEngine;

public class BuildingVisualEffects : MonoBehaviour
{
    [SerializeField] private ShakeScaleAnimation _placementAnimation;

    public void PlayPlacementAnimation()
    {
        _placementAnimation.Shake();
    }
}
