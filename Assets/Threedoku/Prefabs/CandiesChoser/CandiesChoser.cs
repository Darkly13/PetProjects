using UnityEngine;
using System.Collections.Generic;

public class CandiesChoser : MonoBehaviour
{
    [SerializeField] private List<ChoiseCell> _cells;
    
    public Cell Picked { get; private set; }

    private Candies _candies;

    public void Start()
    {
        _candies = Candies.Instant;
    }

    public void Enable()
    {
        foreach (var cell in _cells)
        {
            cell.OnCellPickedEvent += OnCellPicked;
            cell.SetValue(_candies.GetRandomCandy());
        }
    }

    public void Disable()
    {
        foreach (var cell in _cells)
        {
            cell.OnCellPickedEvent -= OnCellPicked;
        }
    }

    public void CreateRandomCandy()
    {
        Picked.SetValue((byte)_candies.GetRandomCandy());
        Picked = null;
    }

    private void OnCellPicked(Cell cell)
    {
        Picked = cell;
    }  
}
