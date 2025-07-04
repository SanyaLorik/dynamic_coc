using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct SpawnpointSpawnerWithPrefab<T> where T : UnityEngine.Object
    {
        [SerializeField] private SpawnpointSpawner<T> _spawner;

        [field: SerializeField] public T Prefab { get; private set; }

        public T Spawn()
        {
            return _spawner.Spawn(Prefab);
        }
    }
}