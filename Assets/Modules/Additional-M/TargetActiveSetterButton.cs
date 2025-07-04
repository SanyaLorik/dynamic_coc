using UnityEngine;
using UnityEngine.UI;

public class TargetActiveSetterButton : MonoBehaviour
{
    [SerializeField] private Button _button; // Ссылка на кнопку
    [SerializeField] private GameObject _target; // Ссылка на цель
    [SerializeField] private bool _activeToSet;

    private void Awake()
    {
        if (_button != null) 
            _button.onClick.AddListener(SetActive);
    }
    
    private void SetActive()
    {
        if (_target != null) 
            _target.SetActive(_activeToSet);
    }

    private void OnDestroy()
    {
        if (_button != null) 
            _button.onClick.RemoveListener(SetActive);
    }
}