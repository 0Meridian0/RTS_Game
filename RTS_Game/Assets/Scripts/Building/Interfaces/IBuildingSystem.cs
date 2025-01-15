using UnityEngine;

public interface IBuildingSystem
{
    bool IsBuilding{ get; }
    void StartBuilding(string buildingName);
    void UpdateBuildingPosition(Vector3 newPosition);
    void PlaceBuilding();
    void CancelBuilding();
}