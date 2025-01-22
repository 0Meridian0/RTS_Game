using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour, IUnit
{
    public float Speed = 5f;
    public Vector3 TargetPosition;
    protected UnitActionFlags _currentUnitActions;

    private const int PATROLWAITINGTIME = 1000;

    public async UniTask MoveTo(Vector3 position)
    {
        SetAction(UnitActionFlags.Move);
        TargetPosition = position;

        await Move();

        RemoveAction(UnitActionFlags.Move);
        Debug.Log($"{gameObject.name} reached the target posiition!");
    }

    public async UniTask Patrol(Vector3 point1, Vector3 point2)
    {
        SetAction(UnitActionFlags.Patrol);

        while (IsActionActive(UnitActionFlags.Patrol))
        {
            await MoveTo(point1);
            await UniTask.Delay(PATROLWAITINGTIME);
            await MoveTo(point2);
            await UniTask.Delay(PATROLWAITINGTIME);
        }

        Debug.Log($"{gameObject.name} has completed patrolling.");
    }

    public virtual async UniTask Attack(GameObject target)
    {
        SetAction(UnitActionFlags.Attack);

        Debug.Log($"{gameObject.name} is attacking {target.name}!");
        await UniTask.Yield();

        RemoveAction(UnitActionFlags.Attack);
    }

    public virtual void StopAction()
    {
        _currentUnitActions = UnitActionFlags.Idle;

        Debug.Log($"{gameObject.name} cancel all actions.");
    }

    public UnitActionFlags GetUnitActionFlags()
    {
        return _currentUnitActions;
    }

    protected void SetAction(UnitActionFlags action)
    {
        _currentUnitActions |= action;
    }

    protected void RemoveAction(UnitActionFlags action)
    {
        _currentUnitActions &= ~action;
    }

    protected bool IsActionActive(UnitActionFlags action)
    {
        return (_currentUnitActions & action) == action;
    }

    private async UniTask Move()
    {
        while (Vector3.Distance(transform.position, TargetPosition) > 0.1f && 
              (_currentUnitActions & UnitActionFlags.Move) == UnitActionFlags.Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
            await UniTask.Yield();
        }
    }
}