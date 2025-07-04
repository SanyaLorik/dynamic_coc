using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        [field: SerializeField] public K Key { get; private set; }

        [field: SerializeField] public V Value { get; private set; }
    }
}