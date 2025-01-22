using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildingUI : MonoBehaviour, IBuildingUI
{
    public bool IsMenuActive {get; private set;} = false;

    [SerializeField] private GameObject uiPanel;
    [SerializeField] private Button[] buildingButtons;

    [Inject] private IBuildingSystem _buildingSystem;
    private string _selectedBuildingName;

    private void Start()
    {
        uiPanel.SetActive(false);

        foreach (var button in buildingButtons)
        {
            button.onClick.AddListener(() => SelectBuilding(button.name));
        }
    }

    public void ShowBuildingMenu()
    {
        IsMenuActive = true;
        uiPanel.SetActive(true);
    }

    public void HideBuildingMenu()
    {
        IsMenuActive = false;
        uiPanel.SetActive(false);
    }

    public string GetSelectedBuildingName()
    {
        return _selectedBuildingName;
    }

    private void SelectBuilding(string buildingName)
    {
        _selectedBuildingName = buildingName;
        _buildingSystem.StartBuilding(buildingName);
        HideBuildingMenu();
    }
}