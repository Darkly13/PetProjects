using UnityEngine;

public class GameFieldView : MonoBehaviour
{
    [SerializeField] private GameField _model;
    [SerializeField] private RectTransform _container;
    [Range(0,1)] [SerializeField] private float _paddingSize;

    private Vector2 _cellSize;
    private Vector2Int _fieldSize;
    private Vector2 _halfFieldSize;
    private Vector2Int _countOfPaddings;
    private float _paddingBetweenCenters;

    public void OnEnable()
    {
        _model.OnGameFieldCreatedEvent += OnGameFieldCreated;
    }

    public void OnDisable()
    {
        _model.OnGameFieldCreatedEvent -= OnGameFieldCreated;
    }

    private void OnGameFieldCreated(FieldCell[,] gameField)
    {
        RememberValues(gameField.GetLength(0), gameField.GetLength(1));
        _cellSize = CalculateCellSize();
        PlaceCells(gameField);
        SetFieldSize();
    }

    private void RememberValues(int xSize, int ySize)
    {
        _fieldSize = new Vector2Int(xSize, ySize);
        _halfFieldSize = new Vector2((float)_fieldSize.x / 2, (float)_fieldSize.y / 2);
        _countOfPaddings = new Vector2Int(_fieldSize.x + 1, _fieldSize.y + 1);
    }

    private Vector2 CalculateCellSize()
    {
        Vector2 filedScale = _container.sizeDelta;
        float cellScale;
        if (_fieldSize.x >= _fieldSize.y)
            cellScale = CalculateCellScaleBySideScale(_fieldSize.x, filedScale.x);
        else
            cellScale = CalculateCellScaleBySideScale(_fieldSize.y, filedScale.y);
        return new Vector2(cellScale, cellScale);
    }

    private float CalculateCellScaleBySideScale(int countOfCells, float sideScale)
    {
        int countOfPaddings = countOfCells + 1;
        float absoluteSizeInCells = countOfCells + countOfPaddings * _paddingSize;
        float cellSize = sideScale / absoluteSizeInCells;
        _paddingBetweenCenters = cellSize * _paddingSize;
        return cellSize;
    }

    private void PlaceCells(FieldCell[,] gameField)
    {
        foreach (FieldCell cell in gameField)
            PlaceCell(cell);
    }

    private void PlaceCell(FieldCell cell)
    {
        float x = (-_halfFieldSize.x + cell.X) * (_cellSize.x + _paddingBetweenCenters) + (_cellSize.x / 2 + _paddingBetweenCenters / 2);
        float y = (-_halfFieldSize.y + cell.Y) * (_cellSize.y + _paddingBetweenCenters) + (_cellSize.y / 2 + _paddingBetweenCenters / 2);
        RectTransform rect = cell.GetComponent<RectTransform>();
        rect.localPosition = new Vector2(x, y);
        rect.sizeDelta = _cellSize;
    }

    private void SetFieldSize()
    {
        float x = (_fieldSize.x * _cellSize.x) + (_countOfPaddings.x * _paddingBetweenCenters);
        float y = (_fieldSize.y * _cellSize.y) + (_countOfPaddings.y * _paddingBetweenCenters);
        GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
    }
}
