using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct OnlyContianerPrefabSpawner<T> where T : UnityEngine.Object
    {
        [SerializeField] private Transform _container;
        [SerializeField] private T _prefab;

        public T Spawn()
        {
            return UnityEngine.Object.Instantiate(_prefab, _container);
        }
    }
}