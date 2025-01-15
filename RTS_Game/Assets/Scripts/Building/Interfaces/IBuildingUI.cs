public interface IBuildingUI
{
    bool IsMenuActive { get; }
    void ShowBuildingMenu();
    void HideBuildingMenu();
    string GetSelectedBuildingName();
}