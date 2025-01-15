using UnityEngine;

public class Laboratory : BaseBuilding
{
    private void Start()
    {
        Name = "Laboratory";
        Health = 300;
    }

    public override void PlaceBuilding()
    {
        base.PlaceBuilding();
        Debug.Log($"{Name} is generating resources.");
    }
}