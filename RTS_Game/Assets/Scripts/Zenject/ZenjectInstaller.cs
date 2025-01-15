using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBuildingSystem>().To<BuildingSystem>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IBuildingUI>().To<BuildingUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputHandler>().FromComponentInHierarchy().AsSingle();
    }
}