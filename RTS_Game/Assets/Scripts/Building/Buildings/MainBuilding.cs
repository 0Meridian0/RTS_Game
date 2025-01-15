using UnityEngine;

public class MainBuilding : BaseBuilding
{
    private void Start()
    {
        Name = "MainBuilding";
        Health = 1000;
    }

    public override void PlaceBuilding()
    {
        base.PlaceBuilding();
        Debug.Log($"{Name} is generating resources.");
    }
}