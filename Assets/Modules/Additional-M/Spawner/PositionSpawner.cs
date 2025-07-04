using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct PositionSpawner<T> where T : UnityEngine.Object
    {
        [field: SerializeField] public Transform Container { get; private set; }

        public T Spawn(T prefab, Vector3 position)
        {
            return UnityEngine.Object.Instantiate(prefab, position, Container.rotation, Container);
        }
    }
}