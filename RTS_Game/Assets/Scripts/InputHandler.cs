using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Ground _ground;

    [Inject] private IBuildingUI _buildingUI;
    [Inject] private IUnitUI _unitUI;
    [Inject] private IBuildingSystem _buildingSystem;

    private void Update()
    {
        if(!_buildingSystem.IsBuilding)
        {
            if(Input.GetMouseButtonDown(1))
            {
                _buildingUI.ShowBuildingMenu();
            }

            if(Input.GetMouseButtonDown(0))
            {
                GetUnit();
            }
        }

        PlacementSelection();
    }

    private void PlacementSelection()
    {
        if(_buildingSystem.IsBuilding)
        {
            var worldPosition = GetWorldPositionFromInput();
            _buildingSystem.UpdateBuildingPosition(worldPosition);

            if(Input.GetMouseButtonDown(0))
            {
                _buildingSystem.PlaceBuilding();
            }

            if(Input.GetMouseButtonDown(1))
            {
                _buildingSystem.CancelBuilding();
            }
        }
    }

    private Vector3 GetWorldPositionFromInput()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log($"Ray origin: {ray.origin}, direction: {ray.direction}");

        if (_ground.GetComponent<Collider>().Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            var position = hit.point;
            position.y = 0;
            return position;
        }

        return Vector3.zero;
    }

    private void GetUnit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            var unit = hit.collider.GetComponent<IUnit>();
            if(unit != null)
            {
                _unitUI.ShowUnitMenu(unit);
            }
        }
    }
}