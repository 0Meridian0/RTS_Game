using UnityEngine;

public abstract class BaseBuilding : MonoBehaviour, IBuilding
{
    public string Name { get; protected set; }
    public int Health { get; protected set; } = 100;

    public virtual void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public virtual void PlaceBuilding()
    {
        Debug.Log($"{Name} placed at {transform.position}");
        Debug.Log($"{Name} with Health: {Health}");
    }

    public virtual void DestroyBuilding()
    {
        Debug.Log($"{Name} was destroyed.");
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            //TODO анимация разрушения здания
            Destroy(gameObject);
        }
    }
}
