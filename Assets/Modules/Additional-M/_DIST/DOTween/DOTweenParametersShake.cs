using System;
using UnityEngine;

namespace _KotletaGames.ArchitectureCore_M.Additional 
{
    [Serializable]
    public class DOTweenParametersShake : DOTweenParametersBase
    {
        [field: SerializeField] public float Strenght { get; private set; }
        [field: SerializeField] public int Vibrato { get; private set; }
    }
}