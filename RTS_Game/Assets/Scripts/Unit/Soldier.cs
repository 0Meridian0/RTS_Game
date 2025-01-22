using Zenject;

public class Soldier : BaseUnit 
{
    private IResourceManager _resourcesManager;
    
    [Inject]
    public void Construct(IResourceManager resourcesManager)
    {
        _resourcesManager = resourcesManager;
    }

}