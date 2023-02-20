using UnityEngine;
using System;

public class Menu : MonoBehaviour
{
    public event Action<FieldInfo> OnStartButtonPressedEvent;

    [SerializeField] private FieldSizeSelector _fieldSizeSelector;
    [SerializeField] private SoundController _soundController;

    public void Awake()
    {
        if (_fieldSizeSelector == null)
            throw new NullReferenceException();
    }

    public void StartButtonClicked()
    {
        _soundController.PlayButtonSound();
        OnStartButtonPressedEvent?.Invoke(_fieldSizeSelector.CurrentInfo);
        gameObject.SetActive(false);
    }
}
