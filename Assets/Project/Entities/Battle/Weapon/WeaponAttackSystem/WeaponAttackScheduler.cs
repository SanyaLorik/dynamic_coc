using _KotletaGames.Additional_M;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

public class WeaponAttackScheduler 
{
    private readonly Action _attacking;
    private readonly Func<bool> _awaiter;
    private readonly ReactiveValue<float> _delay;

    private CancellationTokenSource _tokenSource;

    public WeaponAttackScheduler(Action attacking, Func<bool> awaiter, ReactiveValue<float> delay)
    {
        _attacking = attacking;
        _awaiter = awaiter;
        _delay = delay;
    }

    public async UniTaskVoid Start()
    {
        _tokenSource = new();

        do
        {
            _attacking.Invoke();

            await UniTask.Delay(_delay.Value.ToDelayMillisecond(), cancellationToken: _tokenSource.Token);
            await UniTask.WaitWhile(() => _awaiter.Invoke() == false);
        }
        while (_tokenSource.IsCancellationRequested == false);
    }

    public void Stop()
    {
        _tokenSource?.Cancel();
        _tokenSource?.Dispose();
    }
}
