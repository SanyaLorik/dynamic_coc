using UnityEngine;
using Zenject;

public class GameConfigInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(GameConfig))
            .FromInstance(_gameConfig)
            .AsCached()
            .NonLazy();
    }
}