using UnityEngine;

public class Currency : MonoBehaviour
{
    [field: SerializeField] public Wallet Coins { get; private set; }
    [field: SerializeField] public Wallet Gems { get; private set; }
}