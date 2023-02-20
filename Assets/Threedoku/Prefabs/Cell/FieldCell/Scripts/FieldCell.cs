using System;

[Serializable]
public class FieldCell : Cell
{
    public override event Action<Cell> OnCellPickedEvent;

    public int X { get; private set; }
    public int Y { get; private set; }

    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override void Pick()
    {
        OnCellPickedEvent?.Invoke(this);
    }
}
