using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private InputJoystick _joystick;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(InputJoystick))
            .FromInstance(_joystick)
            .AsCached()
            .NonLazy();
    }
}
