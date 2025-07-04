using System;
using UnityEngine;

namespace _KotletaGames.Additional_M.CustomBarModule
{
    [Serializable]
    public class CustomProgressBarArrayValue : ArrayValueSetup<float>
    {
        [SerializeField] private CustomProgressBar[] _customProgressBars;

        public override void Setup(float value)
        {
            foreach (var customProgressBar in _customProgressBars)
                customProgressBar.SetValue(value);
        }
    }
}