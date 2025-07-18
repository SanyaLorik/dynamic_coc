using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public bool IsAllowDamage => true;

    public void Damage(int value)
    {
        print("По игроку был нанесен урон!");
    }
}