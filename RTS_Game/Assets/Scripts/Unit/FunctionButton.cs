using UnityEngine;

public class FunctionButton : MonoBehaviour
{
    [SerializeField] private UnitActionFlags _unitActionFlags = UnitActionFlags.None;

    public UnitActionFlags GetUnitActionFlag()
    {
        return _unitActionFlags;
    }
}