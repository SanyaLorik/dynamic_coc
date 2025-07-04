using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public class AutoRemovedSpawner<T> where T : UnityEngine.Object
    {
        [SerializeField] private DefualtSpawner<T> _spawner;

        private T _instantiated;

        public T Spawn(T prefab)
        {
            if (_instantiated != null)
                UnityEngine.Object.Destroy(_instantiated);

            _instantiated = _spawner.Spawn(prefab);
            return _instantiated;
        }
    }
}