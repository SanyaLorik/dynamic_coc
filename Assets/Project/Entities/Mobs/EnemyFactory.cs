using _KotletaGames.Additional_M;
using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private PositionSpawner<EnemyAbstract> _spawner;
    [SerializeField] private KindsZombie _kinds;
    [SerializeField] private EnemyDislocation _dislocation;

    [Inject] private DiContainer _diContainer;

    public EnemyAbstract Create()
    {
        EnemyAbstract prefab = _kinds.GetPrefab();
        Vector3 position = _dislocation.GetPosition();

        EnemyAbstract enemyAbstract = _spawner.Spawn(prefab, position);
        _diContainer.Inject(enemyAbstract);

        return enemyAbstract;   
    }
}
