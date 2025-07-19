using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct PrefabSpawner<T> where T : UnityEngine.Object
    {
        [field: SerializeField] public Transform Spawnpoint { get; private set; }
        [field: SerializeField] public T Prefab { get; private set; }

        public T Spawn()
        {
            return UnityEngine.Object.Instantiate(Prefab, Spawnpoint.position, Quaternion.identity);
        }
    }
}