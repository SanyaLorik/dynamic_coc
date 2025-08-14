using UnityEngine;

public class BuildingEconomics : MonoBehaviour
{
    [SerializeField] private float _price;

    public float GetPrice() => _price;

    public bool CanAfford(float currentMoney) => currentMoney >= _price;
}
