using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PointerClickHandler<T> : MonoBehaviour, IPointerClickHandler 
    where T : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer; // ����, �� ������� ��������� ������� ���� T

    private const float maxRaycastDistance = Mathf.Infinity;

    public event Action<T> OnTargetClicked; // ������� ��� ����� �� ������ ���� T

    public void OnPointerClick(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out RaycastHit hit, maxRaycastDistance, _targetLayer, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.TryGetComponent<T>(out var target))
                OnTargetClicked?.Invoke(target);
        }
    }
}
