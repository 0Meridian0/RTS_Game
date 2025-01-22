using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IUnit
{
    UniTask MoveTo(Vector3 position);
    UniTask Patrol(Vector3 point1, Vector3 point2);
    UniTask Attack(GameObject target);
    void StopAction();
}