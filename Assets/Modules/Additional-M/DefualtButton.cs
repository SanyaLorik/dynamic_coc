using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _KotletaGames.Additional_M.Ui
{
    [RequireComponent(typeof(Image))]
    public class DefualtButton : DefualtClickedElement
    {
        private ColorFader _colorFader;

        protected override void Start()
        {
            base.Start();
            _colorFader = new ColorFader(GetComponentsInChildren<Graphic>(true));
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            _colorFader.Fade();
            ChangeSpriteToState2();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            _colorFader.Unfade();
            ChangeSpriteToState1();
        }

        public override void ForceUnpress()
        {
            base.ForceUnpress();
            _colorFader.Unfade();
        }
    }
}