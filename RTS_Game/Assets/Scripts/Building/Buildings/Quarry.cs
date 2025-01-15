using UnityEngine;

public class Quarry : BaseBuilding
{
    private void Start()
    {
        Name = "Quarry";
        Health = 300;
    } 

    public override void PlaceBuilding()
    {
        base.PlaceBuilding();
        Debug.Log($"{Name} is generating resources.");
    }
}