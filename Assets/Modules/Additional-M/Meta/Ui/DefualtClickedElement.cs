using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _KotletaGames.Additional_M.Ui
{
    [RequireComponent(typeof(Image))]
    public abstract class DefualtClickedElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject _state1;
        [SerializeField] private GameObject _state2;

        public event Action OnClicked;
        public event Action OnStarted;
        public event Action OnCanceled;

        private Vector2 _positionDown = Vector2.zero;

        protected Image Surface { get; private set; }

        protected virtual void Start()
        {
            Surface = GetComponent<Image>();
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            Tap(eventData.position);
            OnStarted?.Invoke();
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            Untap(eventData.position);
            OnCanceled?.Invoke();
        }

        public virtual void ForceUnpress()
        {
            OnCanceled?.Invoke();
            ChangeSpriteToState1();
        }

        protected void ChangeSpriteToState1()
        {
            _state1.SetActive(true);
            _state2.SetActive(false);
        }

        protected void ChangeSpriteToState2()
        {
            _state1.SetActive(false);
            _state2.SetActive(true);
        }

        private void Tap(Vector2 position)
        {
            _positionDown = position;
        }

        private void Untap(Vector2 position)
        {
            float distance = Vector2.Distance(position, _positionDown);
            if (distance <= UiConstants.DistanceTap)
                OnClicked?.Invoke();
        }
    }
}