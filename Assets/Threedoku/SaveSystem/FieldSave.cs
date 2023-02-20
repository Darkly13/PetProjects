using UnityEngine;
using System.Collections.Generic;

public class FieldSave : ISerializationCallbackReceiver
{
    [SerializeField] private List<Package<int>> _serializableField;
    public Vector2Int Size;
    public int Score;
    public int[,] Cells { get; private set; }
    
    public FieldSave(FieldCell[,] field, int score)
    {
        Size = new Vector2Int(field.GetLength(0), field.GetLength(1));
        InitializeCells(field);
        Score = score;
    }

    public void InitializeCells(FieldCell[,] field)
    {
        Cells = new int[Size.x, Size.y];

        foreach (var cell in field)
        {
            Cells[cell.X, cell.Y] = cell.Value;
        }
    }

    public void OnBeforeSerialize()
    {
        int index0 = Size.x;
        int index1 = Size.y;
        
        _serializableField = new List<Package<int>>();

        for(int i=0; i<index0; i++)
        {
            for(int j=0; j<index1; j++)
            {
                _serializableField.Add(new Package<int>(i, j, Cells[i, j]));
            }
        }
    }

    public void OnAfterDeserialize()
    {
        Cells = new int[Size.x, Size.y];
        foreach(var cell in _serializableField)
        {
            Cells[cell.Index0, cell.Index1] = cell.Element;
        }
    }
}
