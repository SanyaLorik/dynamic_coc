using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public struct SerializableStructArray<T>
    {
        [field: SerializeField] public T[] Array { get; private set; }
    }
}