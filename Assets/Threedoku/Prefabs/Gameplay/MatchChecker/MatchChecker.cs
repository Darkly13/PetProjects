using UnityEngine;
using System.Collections.Generic;

public class MatchChecker
{
    private FieldCell[,] _cells;
    
    public MatchChecker(FieldCell[,] cells)
    {
        _cells = cells;
    }

    public bool TryMatch(FieldCell cell, out int count)
    {
        int matched = 0;
        bool isThereVertical = TryFindVerticalLine(cell, ref matched, out List<FieldCell> verticalLine);
        bool isThereHorizontal = TryFindHorizontalLine(cell, ref matched, out List<FieldCell> horizontalLine);
        count = matched+1;
        if (isThereVertical || isThereHorizontal)
        {
            cell.Clear();
            if (isThereVertical)
                ClearLine(verticalLine);
            if (isThereHorizontal)
                ClearLine(horizontalLine);
            return true;
        }
        else
            return false;
    }

    private bool TryFindVerticalLine(FieldCell cell, ref int matched, out List<FieldCell> line)
    {
        var upper = CheckLineHalf(cell, Vector2Int.down);
        var lower = CheckLineHalf(cell, Vector2Int.up);
        line = UniteLineHalfs(upper, lower);
        matched += line.Count;
        return CheckLineCount(line);
    }

    private bool TryFindHorizontalLine(FieldCell cell, ref int matched, out List<FieldCell> line)
    {
        var lefter = CheckLineHalf(cell, Vector2Int.left);
        var righter = CheckLineHalf(cell, Vector2Int.right);
        line = UniteLineHalfs(lefter, righter);
        matched += line.Count;
        return CheckLineCount(line);
    }

    private List<FieldCell> CheckLineHalf(FieldCell cell, Vector2Int direction)
    {
        bool isVertical = Mathf.Abs(direction.y) > 0;
        int changable = isVertical ? cell.Y : cell.X;
        int step = isVertical ? direction.y : direction.x;
        int fieldSize = _cells.GetLength(Mathf.Abs(direction.y));
        int value = cell.Value;
        Vector2Int position = new Vector2Int(cell.X, cell.Y) + direction;
        List<FieldCell> same = new List<FieldCell>();

        for (int i = changable + step; i >= 0 && i < fieldSize; i += step, position += direction)
        {
            FieldCell currentCell = _cells[position.x, position.y];
            if (currentCell.Value == value)
                same.Add(currentCell);
            else
                break;
        }
        return same;
    }

    private List<FieldCell> UniteLineHalfs(List<FieldCell> a, List<FieldCell> b)
    {
        List<FieldCell> line = new List<FieldCell>();
        line.AddRange(a);
        line.AddRange(b);
        return line;
    }

    private bool CheckLineCount(List<FieldCell> line)
    {
        return line.Count >= 2;
    }

    private void ClearLine(List<FieldCell> line)
    {
        foreach (var cell in line)
            cell.Clear();
    }
}
