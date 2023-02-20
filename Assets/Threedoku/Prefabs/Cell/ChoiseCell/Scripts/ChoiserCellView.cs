using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ChoiserCellView : CellView
{
    private Toggle _toggle;

    public override void Awake()
    {
        base.Awake();
        _toggle = GetComponent<Toggle>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        _toggle.onValueChanged.RemoveListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool isActive)
    {
        if (isActive)
        {
            _toggle.isOn = false;
            OnCellClicked();
        }
            
    }
}
