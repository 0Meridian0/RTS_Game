using System.Collections.Generic;

public class ResourceManager : IResourceManager
{
    private readonly Dictionary<ResourceType, int> _resources;

    public ResourceManager()
    {
        _resources = new Dictionary<ResourceType, int>
        {
            {ResourceType.Wood, 200},
            {ResourceType.Rock, 200},
            {ResourceType.Gold, 100},
            {ResourceType.UnitSpace, 800}
        };
    }

    public void AddResource(ResourceType resourceType, int amount)
    {
        if(!_resources.ContainsKey(resourceType))
        {
            _resources[resourceType] = 0;
        }

        _resources[resourceType] += amount;
    }
    
    public void RemoveResource(ResourceType resourceType, int amount)
    {
        if(!_resources.ContainsKey(resourceType) || _resources[resourceType] - amount < 0)
        {
            _resources[resourceType] = 0;
        }
        else
        {
            _resources[resourceType] -= amount;
        }
    }

    public int GetResourceAmount(ResourceType resourceType)
    {
        return _resources.ContainsKey(resourceType) ? _resources[resourceType] : 0;
    }
}