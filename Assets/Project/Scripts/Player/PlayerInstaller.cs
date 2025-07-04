using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Rigidbody _rigidbody;

    public override void InstallBindings()
    {
        BindMovement();
    }

    private void BindMovement()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(PlayerMovement))
            .AsCached()
            .WithArguments(_rigidbody);
    }
}