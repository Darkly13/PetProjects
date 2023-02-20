using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HighScoreView : MonoBehaviour
{
    [SerializeField] private HighScore _highScore;

    private TextMeshProUGUI _textMesh;

    public void Awake()
    {
        if (_highScore == null)
            throw new NullReferenceException();

        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        _highScore.OnChanged += OnChanged;
    }

    public void OnDisable()
    {
        _highScore.OnChanged -= OnChanged;
    }

    private void OnChanged(int value)
    {
        _textMesh.text = value.ToString();
    }
}
