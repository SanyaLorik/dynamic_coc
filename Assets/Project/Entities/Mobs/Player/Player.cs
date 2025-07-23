using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public TeamType Team { get; private set; }

    public bool IsAllowDamage => true;

    public void Damage(int value)
    {
        print("По игроку был нанесен урон!");
    }
}