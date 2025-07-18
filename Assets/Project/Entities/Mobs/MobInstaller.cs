using Zenject;

public class MobInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindMobDirector();
    }

    private void BindMobDirector()
    {
        Container
            .BindInterfacesAndSelfTo(typeof(MobDirector))
            .AsCached();
    }
}