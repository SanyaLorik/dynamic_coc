using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct SpawnpointSpawner<T> where T : UnityEngine.Object
    {
        [field: SerializeField] public Transform Spawnpoint { get; private set; }

        public T Spawn(T prefab)
        {
            return UnityEngine.Object.Instantiate(prefab, Spawnpoint.position, Spawnpoint.rotation);
        }
    }
}