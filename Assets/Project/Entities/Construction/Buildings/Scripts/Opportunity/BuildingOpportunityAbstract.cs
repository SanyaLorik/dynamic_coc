using UnityEngine;

public abstract class BuildingOpportunityAbstract : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isAvailable = true;

    public Sprite Icon => _icon;
    public bool IsAvailable => _isAvailable;

    public abstract void Execute();
}
