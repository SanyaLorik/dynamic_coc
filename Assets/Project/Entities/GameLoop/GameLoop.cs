using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;

    private void Start()
    {
        EnemyAbstract enemy = _enemyFactory.Create();
    }
}
