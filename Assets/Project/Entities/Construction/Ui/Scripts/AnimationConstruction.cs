using _KotletaGames.Additional_M;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class AnimationConstruction
{
    [SerializeField] private AnimationAbstract[] _startBuildings;
    [SerializeField] private AnimationAbstract[] _stopBuildings;

    public async UniTaskVoid Show()
    {
        UniTask[] stopTaks = new UniTask[_stopBuildings.Length];
        _stopBuildings.ForEachWithIndexer((s, i) => stopTaks[i] = s.Hide().AsyncWaitForCompletion().AsUniTask());
        await UniTask.WhenAll(stopTaks);

        UniTask[] startTaks = new UniTask[_startBuildings.Length];
        _startBuildings.ForEachWithIndexer((s, i) => startTaks[i] = s.Show().AsyncWaitForCompletion().AsUniTask());
        await UniTask.WhenAll(startTaks);
    }

    public async UniTaskVoid Hide()
    {
        UniTask[] startTaks = new UniTask[_startBuildings.Length];
        _startBuildings.ForEachWithIndexer((s, i) => startTaks[i] = s.Hide().AsyncWaitForCompletion().AsUniTask());
        await UniTask.WhenAll(startTaks);

        UniTask[] stopTaks = new UniTask[_stopBuildings.Length];
        _stopBuildings.ForEachWithIndexer((s, i) => stopTaks[i] = s.Show().AsyncWaitForCompletion().AsUniTask());
        await UniTask.WhenAll(stopTaks);
    }
}