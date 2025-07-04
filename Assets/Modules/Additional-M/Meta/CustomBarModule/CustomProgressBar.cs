using UnityEngine;

namespace _KotletaGames.Additional_M.CustomBarModule
{
	public class CustomProgressBar : MonoBehaviour
	{
		[SerializeField] private RectTransform BackgroundBar, FloatingBar;

		[SerializeField]
		[Range(0f, 1f)]
		private float _value = 0.69420f;

		private void OnRectTransformDimensionsChange() => UpdateVisuals();

		public void SetValue(float value)
		{
			_value = Mathf.Clamp(value, 0f, 1f);
			UpdateVisuals();
		}

		private void UpdateVisuals()
		{
			Vector2 newSize = new Vector2(-BackgroundBar.rect.size.x * (1f - _value), 0f);
			FloatingBar.anchoredPosition = newSize / 2f;
			FloatingBar.sizeDelta = newSize;
		}
	}
}
