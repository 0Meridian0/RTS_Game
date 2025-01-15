using UnityEngine;

public class Sawmill : BaseBuilding
{
    private void Start()
    {
        Name = "Sawmill";
        Health = 300;
    }

    public override void PlaceBuilding()
    {
        base.PlaceBuilding();
        Debug.Log($"{Name} is generating resources.");
    }
}