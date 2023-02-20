using System;

public class ChoiseCell : Cell
{
    public override event Action<Cell> OnCellPickedEvent;

    public override void Pick()
    {
        OnCellPickedEvent?.Invoke(this);
    }
}
