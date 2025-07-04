using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct DefualtSpawnerWithPrefab<T> where T : UnityEngine.Object
    {
        [field: SerializeField] public DefualtSpawner<T> Spawner { get; private set; }

        [field: SerializeField] public T Prefab { get; private set; }

        public T Spawn()
        {
            return Spawner.Spawn(Prefab);
        }
    }
}