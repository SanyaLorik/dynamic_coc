using _KotletaGames.Additional_M;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void SetPosition(Vector3 target)
    {
        _effect.transform.position = target;
    }

    public async UniTask Play()
    {
        _effect.Play();

        float delay = _effect.totalTime;
        await UniTask.Delay(delay.ToDelayMillisecond(), cancellationToken: destroyCancellationToken);
    }
}