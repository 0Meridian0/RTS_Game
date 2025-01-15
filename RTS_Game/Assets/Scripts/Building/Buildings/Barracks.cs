using UnityEngine;

public class Barracks : BaseBuilding
{
    private void Start()
    {
        Name = "Barracks";
        Health = 300;
    }

    public override void PlaceBuilding()
    {
        base.PlaceBuilding();
        Debug.Log($"{Name} is generating resources.");
    }
}