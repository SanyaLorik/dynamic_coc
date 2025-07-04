using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public struct SetContainerSpawner<T> where T : UnityEngine.Object
    {
        public readonly T Spawn(T prefab, Transform container, Transform spawnpoint)
        {
            return UnityEngine.Object.Instantiate(prefab, spawnpoint.position, container.rotation, container);
        }
    }
}