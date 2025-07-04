using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public static class PairedValueExtensions
    {
        public static float Random(this PairedValue pairedValue) => 
            UnityEngine.Random.Range(pairedValue.From, pairedValue.To);
    }
    
    [Serializable]
    public struct PairedValue
    {
        [field: SerializeField] public float From { get; private set; }

        [field: SerializeField] public float To { get; private set; }
    }

    [Serializable]
    public struct PairedValue<T>
    {
        [field: SerializeField] public T From { get; private set; }

        [field: SerializeField] public T To { get; private set; }
    }

    [Serializable]
    public struct PairedValuePosition
    {
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        public Vector3 From => _from.position;

        public Vector3 To => _to.position;
    }
}