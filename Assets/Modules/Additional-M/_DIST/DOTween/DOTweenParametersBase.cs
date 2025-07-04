using System;
using DG.Tweening;
using UnityEngine;

namespace _KotletaGames.ArchitectureCore_M.Additional
{
    [Serializable]
    public class DOTweenParametersBase
    {
        [field: SerializeField] public Ease Ease { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
    }
}