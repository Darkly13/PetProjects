using UnityEngine;
using System;

public enum FieldShape
{
    Square,
    Rectangle
}

public class FieldShapeToggle : MenuToggle
{
    public static event Action<FieldShape> OnPicked;

    [SerializeField] private FieldShape _shape;

    protected override void ToggleSelected(bool isActive)
    {
        OnPicked?.Invoke(_shape);
    }
}
