using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;

    private TextMeshProUGUI _textMesh;

    public void Awake()
    {
        if (_score == null)
            throw new NullReferenceException();

        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        _score.Changed += OnChanged;
    }

    public void OnDisable()
    {
        _score.Changed -= OnChanged;
    }

    private void OnChanged(int value)
    {
        _textMesh.text = value.ToString();
    }
}
