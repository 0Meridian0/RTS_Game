using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Worker : BaseUnit, IWorker
{
    public float MiningTime = 2f;

    private IResourceManager _resourcesManager;
    private ResourceType _resourceTypeToGather;
    private GameObject _targetResource;
    private GameObject _deliveryBuilding;

    [Inject]
    public void Construct(IResourceManager resourcesManager)
    {
        _resourcesManager = resourcesManager;
    }
    
    public async UniTask GatherResource(ResourceType resourceType, GameObject targetResource)
    {
        SetAction(UnitActionFlags.GatherResource);
        await MoveTo(targetResource.transform.position);

        Debug.Log($"Mining {resourceType}");

        await UniTask.Delay(2000); //TODO Move to constant

        //await MoveTo(_building);
        await UniTask.Yield();

        _resourcesManager.AddResource(resourceType, 10);
        Debug.Log("Resource delivered!");

        RemoveAction(UnitActionFlags.GatherResource);
    }

    public async UniTask BuildStructure(GameObject buildingPrefab)
    {
        SetAction(UnitActionFlags.Build);

        await MoveTo(buildingPrefab.transform.position);
        await UniTask.Delay(5000); //TODO Move to constant

        Debug.Log("Building constructed!");

        RemoveAction(UnitActionFlags.Build);
    }
}