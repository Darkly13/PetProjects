using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SureScreen : MonoBehaviour
{
    public event Action<bool> OnChoiseMade;

    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    public void Awake()
    {
        if (_yesButton == null)
            throw new NullReferenceException();
        if (_noButton == null)
            throw new NullReferenceException();
    }

    public void OnEnable()
    {
        _yesButton.onClick.AddListener(() => OnChoiseMade?.Invoke(true));
        _noButton.onClick.AddListener(() => OnChoiseMade?.Invoke(false));
    }

    public void OnDisable()
    {
        _yesButton.onClick.RemoveAllListeners();
        _noButton.onClick.RemoveAllListeners();
    }

    public void SetText(string text)
    {
        _label.text = text;
    }
}
