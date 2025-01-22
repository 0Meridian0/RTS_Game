public interface IResourceManager
{
    void AddResource(ResourceType resourceType, int amount);
    void RemoveResource(ResourceType resourceType, int amount);
    int GetResourceAmount(ResourceType resourceType);
}