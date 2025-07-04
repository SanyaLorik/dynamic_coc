using System;
using _KotletaGames.Additional_M;
using DG.Tweening;
using UnityEngine;

namespace _KotletaGames.ArchitectureCore_M.Additional
{
    [Serializable]
    public class DOTweenParametersScale
    {
        [field: SerializeField] public Ease Ease { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public float Strenght { get; private set; }
        [field: SerializeField] public int Vibrato { get; private set; }
        [field: SerializeField] public PairedValue<Vector3> Scale { get; private set; }
    }
}