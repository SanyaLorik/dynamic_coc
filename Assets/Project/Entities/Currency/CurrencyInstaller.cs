using UnityEngine;
using Zenject;

public class CurrencyInstaller : MonoInstaller
{
    [SerializeField] private Currency _currency;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(Currency))
            .FromInstance(_currency)
            .AsCached();
    }
}