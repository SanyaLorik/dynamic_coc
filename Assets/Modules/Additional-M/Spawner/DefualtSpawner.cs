using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct DefualtSpawner<T> where T : UnityEngine.Object
    {
        [field: SerializeField] public Transform Container {  get; private set; }

        [field: SerializeField] public Transform Spawnpoint { get; private set; }

        public T Spawn(T prefab)
        {
            return UnityEngine.Object.Instantiate(prefab, Spawnpoint.position, Container.rotation, Container);
        }
    }
}