using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IWorker
{
    UniTask GatherResource(ResourceType resourceType, GameObject targetResource);
    UniTask BuildStructure(GameObject buildingPrefab);
}
