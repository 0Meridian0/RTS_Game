using UnityEngine;
using Zenject;

public class BuildingSystem : MonoBehaviour, IBuildingSystem
{
    public bool IsBuilding{get; private set;} = false;
    
    [Inject] private DiContainer _diContainer;
    private IBuilding _currentBuilding;

    public void StartBuilding(string buildingName)
    {
        if(IsBuilding) return;

        var buildingPrefab = Resources.Load<BaseBuilding>($"Prefabs/{buildingName}");

        _currentBuilding = _diContainer.InstantiatePrefabForComponent<IBuilding>(buildingPrefab);
        IsBuilding = true;
    }

    public void UpdateBuildingPosition(Vector3 newPosition)
    {
        _currentBuilding?.SetPosition(newPosition);
    }

    public void PlaceBuilding()
    {
        _currentBuilding.PlaceBuilding();
        IsBuilding = false;
        _currentBuilding = null;
    }

    public void CancelBuilding()
    {
        _currentBuilding.DestroyBuilding();
        IsBuilding = false;
        _currentBuilding = null;
    }
}