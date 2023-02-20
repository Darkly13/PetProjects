using UnityEngine;
using System;

public class GameField : MonoBehaviour
{
    public event Action<FieldCell[,]> OnGameFieldCreatedEvent;
    public event Action<Cell> OnCellPickedEvent;

    [SerializeField] private FieldCell _prefab;
    public FieldCell[,] Cells { get; private set; }
    public bool Isloaded { get; private set; }

    private FieldCellsPool _pool; 

    public void Awake()
    {
        _pool = new FieldCellsPool(_prefab, transform, 16);
    }

    public void Init(int xSize, int ySize)
    {
        Cells = new FieldCell[xSize, ySize];      
        for(int x = 0; x<xSize; x++)
        {
            for(int y=0; y<ySize; y++)
            {
                var cell = _pool.GetElement();
                cell.SetPosition(x, y);
                Cells[x, y] = cell;
                cell.OnCellPickedEvent += OnCellPicked;
                cell.gameObject.SetActive(true);
            }
        }
        OnGameFieldCreatedEvent?.Invoke(Cells);
        Isloaded = false;
    }

    public void Set(int[,] loadedCells)
    {
        foreach (var cell in Cells)
            cell.SetValue(loadedCells[cell.X, cell.Y]);
        Isloaded = true;
    }

    public void Clear()
    {
        foreach (FieldCell cell in Cells)
            cell.Clear();
        Isloaded = false;
    }

    public void Delete()
    {
        foreach (var cell in Cells)
        {
            cell.Clear();
            cell.gameObject.SetActive(false);
            cell.OnCellPickedEvent -= OnCellPicked;
        }
    }

    private void OnCellPicked(Cell cell)
    {
        OnCellPickedEvent?.Invoke(cell);
    }
}
