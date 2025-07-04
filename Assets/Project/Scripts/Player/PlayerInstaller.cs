using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Rigidbody _rigidbody;

    public override void InstallBindings()
    {
        BindMovement();
        BindRotation();
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