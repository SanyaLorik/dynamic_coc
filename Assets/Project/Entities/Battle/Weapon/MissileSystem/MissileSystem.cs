using _KotletaGames.Additional_M;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MissileSystem : MonoBehaviour
{
    [SerializeField] private MissileMovement _movement;
    [SerializeField] private MissileDamageExplotion _damageExplotion;
    [SerializeField] private EffectPlayer _destroyEffect;
    [SerializeField] private PrefabSpawner<GameObject> _spawner;

    public async UniTaskVoid Launch(Vector3 target)
    {
        GameObject missile = _spawner.Spawn();
        await _movement.MoveAsync(missile.transform, target);

        _damageExplotion.Explote();

        _destroyEffect.SetPosition(target);
        await _destroyEffect.Play();

        DestroySelf(missile);
    }

    private void DestroySelf(GameObject missile)
    {
        Destroy(missile);
    }
}
