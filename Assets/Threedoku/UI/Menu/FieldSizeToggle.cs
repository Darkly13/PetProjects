using UnityEngine;
using System;

public class FieldSizeToggle : MenuToggle
{
    public static event Action<FieldInfo> OnPicked;

    [SerializeField] private FieldInfo _info;

    protected override void ToggleSelected(bool isActive)
    {
        OnPicked?.Invoke(_info);
    }
}
