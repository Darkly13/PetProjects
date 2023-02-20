using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
public abstract class CellView : MonoBehaviour
{
    [SerializeField] protected Cell _model;

    protected Image _image;
    protected Animator _animator;

    public virtual void Awake()
    {
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
    }

    public virtual void OnEnable()
    {
        _model.OnValueChangedEvent += OnValueChanged;
    }

    public virtual void OnDisable()
    {
        _model.OnValueChangedEvent -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _image.sprite = Candies.Instant.GetSprite(value);
        _animator.SetTrigger("Set");
    }

    protected void OnCellClicked() => _model.Pick();
}
