using System;
using UnityEngine;
using UnityEngine.UI;

public class FieldcellView : CellView
{
    [SerializeField] private Button _button;

    public override void Awake()
    {
        base.Awake();
        if (_button == null)
            throw new NullReferenceException();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _button.onClick.AddListener(OnCellClicked);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        _button.onClick.RemoveListener(OnCellClicked);
    }
}
