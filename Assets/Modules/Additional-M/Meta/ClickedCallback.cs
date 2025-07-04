using System;
using _KotletaGames.Additional_M.Ui;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct ClickedCallback
    {
        [SerializeField] private DefualtClickedElement _clicked;

        public void AddListener(Action action)
        {
            _clicked.OnClicked += action;
        }

        public void RemoveListener(Action action)
        {
            _clicked.OnClicked -= action;
        }
    }
}