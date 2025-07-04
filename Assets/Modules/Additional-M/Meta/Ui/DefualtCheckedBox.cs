using System;
using UnityEngine;
using UnityEngine.UI;

namespace _KotletaGames.Additional_M.Ui
{
    [RequireComponent(typeof(Image))]
    public class DefualtCheckedBox : DefualtClickedElement
    {
        public event Action OnChanged;

        public bool IsChecked { get; private set; } = true;

        private void OnEnable()
        {
            OnClicked += OnChangeState;
        }

        private void OnDisable()
        {
            OnClicked -= OnChangeState;
        }

        public void SetChecking()
        {
            IsChecked = true;
            ChangeSpriteToState1();
        } 

        public void SetUnchecking()
        {
            IsChecked = false;
            ChangeSpriteToState2();
        }

        private void OnChangeState()
        {
            if (IsChecked == true)
                ChangeSpriteToState2();
            else
                ChangeSpriteToState1();

            IsChecked = !IsChecked;
            OnChanged?.Invoke();
        }
    }
}