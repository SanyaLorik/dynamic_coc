using UnityEngine;

[CreateAssetMenu(fileName = "NewCurrency", menuName = "Game/Currency")]
public class CurrencyConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}