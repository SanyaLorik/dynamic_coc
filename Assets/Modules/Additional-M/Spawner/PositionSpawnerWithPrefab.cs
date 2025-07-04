using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct PositionSpawnerWithPrefab<T> where T : UnityEngine.Object
    {
        [field: SerializeField] public PositionSpawner<T> Spawner { get; private set; }
        [field: SerializeField] public T Prefab { get; private set; }

        public T Spawn(Vector3 position)
        {
            return Spawner.Spawn(Prefab, position);
        }
    }
}