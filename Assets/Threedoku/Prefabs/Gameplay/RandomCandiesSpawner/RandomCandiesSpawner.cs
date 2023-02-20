using UnityEngine;
using System.Collections.Generic;

public class RandomCandiesSpawner 
{
    public int FreeCount => _freeCells.Count;

    private Candies _candies;
    private FieldCell[,] _cells;
    private List<Cell> _freeCells;

    public RandomCandiesSpawner(FieldCell[,] cells)
    {
        _candies = Candies.Instant;
        _cells = cells;
    }

    public void UpdateFreeList()
    {
        _freeCells = new List<Cell>();
        foreach (var cell in _cells)
        {
            if(cell.IsEmpty)
                _freeCells.Add(cell);
        }
    }

    public bool TrySpawn()
    {
        return TrySpawn(out FieldCell cell);
    }

    public bool TrySpawn(out FieldCell cell)
    {
        if (_freeCells.Count > 0)
        {
            cell = Spawn();
            return true;
        }
        else
        {
            cell = null;
            return false;
        }  
    }

    private FieldCell Spawn()
    {
        var randomCell = _freeCells[Random.Range(0, _freeCells.Count)];
        randomCell.SetValue(_candies.GetRandomCandy());
        _freeCells.Remove(randomCell);
        return (FieldCell)randomCell;
    }
}
