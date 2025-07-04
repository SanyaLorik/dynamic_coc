using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct ElementActivity
    {
        [SerializeField] private GameObject _menu;

        public void Show()
        {
            _menu.SetActive(true);
        }

        public void Hide()
        {
            _menu.SetActive(false);
        }
    }
}