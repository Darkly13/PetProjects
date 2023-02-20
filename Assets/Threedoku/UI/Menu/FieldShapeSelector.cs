using UnityEngine;
using System;

public class FieldShapeSelector : MonoBehaviour
{
    [SerializeField] private SoundController _soundController;
    [SerializeField] private GameObject _fieldTogglesSquare;
    [SerializeField] private GameObject _fieldTogglesRectangle;

    public void Awake()
    {
        if (_fieldTogglesSquare == null)
            throw new NullReferenceException();
        if (_fieldTogglesRectangle == null)
            throw new NullReferenceException();
    }

    public void OnEnable()
    {
        FieldShapeToggle.OnPicked += ShapePicked;
    }

    public void OnDisable()
    {
        FieldShapeToggle.OnPicked -= ShapePicked;
    }

    private void ShapePicked(FieldShape shape)
    {
        _soundController.PlayButtonSound();
        if (shape == FieldShape.Square)
        {
            _fieldTogglesSquare.SetActive(true);
            _fieldTogglesRectangle.SetActive(false);
        }
        else
        {
            _fieldTogglesRectangle.SetActive(true);
            _fieldTogglesSquare.SetActive(false);
        }
    }
}
