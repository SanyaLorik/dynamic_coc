using UnityEngine;
using Zenject;

public class EnemyReward : MonoBehaviour
{
    [SerializeField] private int _coinsForDead = 10;

    [Inject] private Currency _currency;

    public void GiveReward()
    {
        _currency.Coins.Add(_coinsForDead);
    }
}
