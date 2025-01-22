using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour, IUnitUI
{
    [SerializeField] private GameObject _unitPanel;
    [SerializeField] private Button[] _functionButtons;
    [SerializeField] private Text _nameField;

    private IUnit _unit;
    private bool _isPointsSet = false;
    private int _pointCounter = 0;
    private Vector3 _point1 = Vector3.zero;
    private Vector3 _point2 = Vector3.zero;

    private void Start()
    {
        _unitPanel.SetActive(false);

        foreach (var button in _functionButtons)
        {
            button.onClick.AddListener(async () => await UnitAction(button.GetComponent<FunctionButton>().GetUnitActionFlag()));
            button.gameObject.SetActive(false);
        }
    } 

    public void ShowUnitMenu(IUnit unit)
    {
        _unit = unit;
        _nameField.text = _unit.GetType().ToString();

        HideUnitMenu();

        _unitPanel.SetActive(true);

        if(unit is IWorker)
        {
            foreach (var button in _functionButtons)
            {
                button.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (var button in _functionButtons)
            {
                if (button.GetComponent<FunctionButton>().GetUnitActionFlag() != UnitActionFlags.GatherResource &&
                    button.GetComponent<FunctionButton>().GetUnitActionFlag() != UnitActionFlags.Build)
                {
                button.gameObject.SetActive(true);
                }
            }
        }
    }
    
    public void HideUnitMenu()
    {
        _unitPanel.SetActive(false);
        foreach(var btn in _functionButtons)
        {
            btn.gameObject.SetActive(false);
        }
    }

    private async UniTask UnitAction(UnitActionFlags actionFlags)
    {
        switch (actionFlags)
        {
            case UnitActionFlags.Cancel:
                _unit.StopAction();
                break;

            case UnitActionFlags.Move:
                var position = await GetMovingPosition();
                await _unit.MoveTo(position);
                break;

            case UnitActionFlags.Patrol:
                await SetPatrolPoints();
                await _unit.Patrol(_point1, _point2);
                break;

            case UnitActionFlags.Attack:
                break;

            case UnitActionFlags.GatherResource:
                break;

            case UnitActionFlags.Build:
                break;
        }
    }

    private async UniTask<Vector3> GetMovingPosition()
    {
        while(!Input.GetMouseButtonDown(0))
        {
            await UniTask.Yield();
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            var position = hit.point;
            position.y = 0;
            return position;
        }

        return Vector3.zero;
    }

    private async UniTask SetPatrolPoints()
    {
        while(!_isPointsSet)
        {
            if(Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray,out RaycastHit hit, Mathf.Infinity))
                {
                    if(_pointCounter == 0)
                    {
                        _point1 = hit.point;
                        _point1.y = 0;
                        _pointCounter++;
                    }
                    else
                    {
                        if(_pointCounter == 1)
                        {
                            _point2 = hit.point;
                            _point2.y = 0;
                            _isPointsSet = true;
                        }
                    }
                }
            }

            await UniTask.Yield();
        }

        _isPointsSet = false;
        _pointCounter = 0;
    }
}