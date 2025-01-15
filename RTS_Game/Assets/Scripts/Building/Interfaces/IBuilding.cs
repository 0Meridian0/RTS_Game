using UnityEngine;

public interface IBuilding
{
    string Name { get; }
    int Health { get; }
    void SetPosition(Vector3 position);
    void PlaceBuilding();
    void DestroyBuilding();
    void TakeDamage(int damage);
}