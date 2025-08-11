using UnityEngine;

public class BuildingTargeting : MonoBehaviour, ITargetable
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _offsetByCenter;

    public Vector3 Position => _center.position + _center.forward * _offsetByCenter;

    public float OffsetByCenter => _offsetByCenter;
}