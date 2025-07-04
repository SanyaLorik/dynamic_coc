using System;
using TMPro;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public abstract class ArrayValueSetup<T>
    {
        public abstract void Setup(T value);
    }

    [Serializable]
    public class TextMeshProArraySetup : ArrayValueSetup<string>
    {
        [SerializeField] private TextMeshProUGUI[] _texts;

        public override void Setup(string value)
        {
            foreach (var text in _texts)
                text.text = value;
        }
    }
}