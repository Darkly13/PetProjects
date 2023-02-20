using UnityEngine;

[CreateAssetMenu(fileName = "FieldInfo", menuName = "FieldInfo", order = 0)]
public class FieldInfo : ScriptableObject
{
    [SerializeField] private Vector2Int _fieldSize;
    [SerializeField] private int _candiesCount;

    public Vector2Int FieldSize => _fieldSize;
    public int CandiesCount => _candiesCount;

    public void OnValidate()
    {
        if (_candiesCount < 2)
            _candiesCount = 2;

        if (_fieldSize.x < 2)
            _fieldSize.x = 2;

        if (_fieldSize.y < 2)
            _fieldSize.y = 2;
    }
}
