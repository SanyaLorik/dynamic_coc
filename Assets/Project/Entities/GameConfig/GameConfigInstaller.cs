using System;
using UnityEngine;
using Zenject;

public class GameConfigInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        BindGameConfig();
    }

    private void BindGameConfig()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(GameConfig))
            .FromInstance(_gameConfig)
            .AsCached()
            .NonLazy();
    }
}