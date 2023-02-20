using System;
using UnityEngine;

public abstract class Cell: MonoBehaviour
{
    public abstract event Action<Cell> OnCellPickedEvent;
    public event Action<int> OnValueChangedEvent;
    
    public int Value { get; private set; }
    public bool IsEmpty => Value == 0;

    public void SetValue(int value)
    {
        Value = value;
        OnValueChangedEvent?.Invoke(value);
    }

    public void Clear() => SetValue(0);

    public abstract void Pick();
}
