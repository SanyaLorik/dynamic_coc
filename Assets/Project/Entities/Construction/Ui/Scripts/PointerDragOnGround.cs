using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PointerDragOnGround : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject _ground; // Объект, по которому определяется позиция (например, Plane или Terrain)
    [SerializeField] private LayerMask _groundLayer; // Слой, чтобы Raycast не попадал в другие объекты

    public event Action<Vector3> OnDragPositionChanged; // Событие с передачей позиции
    public event Action<Vector3> OnDragEnded; // Событие при окончании перетаскивания

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        UpdateDragPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateDragPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (TryGetGroundPosition(eventData, out Vector3 position) == true)
            OnDragEnded?.Invoke(position);
    }

    private void UpdateDragPosition(PointerEventData eventData)
    {
        if (TryGetGroundPosition(eventData, out Vector3 position))
            OnDragPositionChanged?.Invoke(position);
    }

    private bool TryGetGroundPosition(PointerEventData eventData, out Vector3 position)
    {
        position = Vector3.zero;
        Ray ray = _mainCamera.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayer))
        {
            if (hit.collider.gameObject == _ground)
            {
                position = hit.point;
                return true;
            }
        }

        return false;
    }
}