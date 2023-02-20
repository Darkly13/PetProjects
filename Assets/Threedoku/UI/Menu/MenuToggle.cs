using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class MenuToggle : MonoBehaviour
{
    private Toggle _toggle;

    public void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    public void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleSelected);
    }

    public void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleSelected);
    }

    protected abstract void ToggleSelected(bool isActive);
}
