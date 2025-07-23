using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Rigidbody _rigidbody;

    public override void InstallBindings()
    {
        BindPlayer();
        BindMovement();
        BindRotation();
    }

    private void BindPlayer()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(Player))
            .AsCached()
            .WithArguments(_rigidbody);
    }

    private void BindMovement()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(PlayerMovement))
            .AsCached()
            .WithArguments(_rigidbody);
    }

    private void BindRotation()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(PlayerRotation))
            .AsCached()
            .WithArguments(_rigidbody);
    }
}
