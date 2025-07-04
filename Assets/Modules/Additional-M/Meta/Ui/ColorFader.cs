using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _KotletaGames.Additional_M.Ui
{
    public struct ColorFader
    {
        private readonly IEnumerable<PairInitalColorWithGraphic> _pair;
        private float _darkReducing;
        private bool _isFaded;

        public ColorFader(IReadOnlyList<Graphic> graphics, float darkReducing = -1)
        {
            PairInitalColorWithGraphic[] pair = new PairInitalColorWithGraphic[graphics.Count];
            for (int i = 0; i < graphics.Count; i++)
                pair[i] = new PairInitalColorWithGraphic(graphics[i], graphics[i].color);

            _pair = pair;
            _darkReducing = darkReducing < 0 ? UiConstants.TapDarkReducing : darkReducing;
            _isFaded = false;
        }

        public void Fade()
        {
            if (_isFaded == true)
                return;

            foreach (var pair in _pair)
            {
                Color color = pair.Color;
                color.r -= _darkReducing;
                color.g -= _darkReducing;
                color.b -= _darkReducing;

                pair.Color = color;
            }

            _isFaded = true;
        }

        public void Unfade() 
        {
            if (_isFaded == false)
                return;

            foreach (var pair in _pair)
                pair.ResetColor();

            _isFaded = false;
        }

        private readonly struct PairInitalColorWithGraphic
        {
            public readonly Color InitalColor;
            private readonly Graphic _graphic;

            public PairInitalColorWithGraphic(Graphic graphic, Color initalColor)
            {
                _graphic = graphic;
                InitalColor = initalColor;
            }

            public Color Color { get => _graphic.color; set => _graphic.color = value; }

            public void ResetColor()
            {
                _graphic.color = InitalColor;
            }
        }
    }
}