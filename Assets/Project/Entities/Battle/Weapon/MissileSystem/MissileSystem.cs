using _KotletaGames.Additional_M;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MissileSystem : MonoBehaviour
{
    [SerializeField] private MissileMovement _movement;
    [SerializeField] private MissileDamageExplotion _damageExplotion;
    [SerializeField] private PrefabSpawner<GameObject> _spawner;

    public async UniTaskVoid Launch(Vector3 target)
    {
        Transform missile =_spawner.Spawn().transform;
        await _movement.MoveAsync(missile, target);
        _damageExplotion.Explote();
    }
}
