using UnityEngine;

public class KindsZombie : MonoBehaviour
{
    [SerializeField] private EnemyAbstract _enemyPrefab;

    public EnemyAbstract GetPrefab()
    {
        return _enemyPrefab;
    }
}
