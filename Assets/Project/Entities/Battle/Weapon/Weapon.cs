using _KotletaGames.Additional_M;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private MissileSystem _missileSystem;
    [field: SerializeField] public ReactiveValue<float> DelayAttacking { get; private set; }
    [field: SerializeField, Min(0)] public int CountTarget { get; private set; }

    public void Shoot(Vector3 target)
    {
        _missileSystem.Launch(target).Forget();
    }
}