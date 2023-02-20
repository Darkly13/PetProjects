using UnityEngine;
using System;

public class HighScore : MonoBehaviour
{
    public event Action<int> OnChanged;

    [SerializeField] private Score _score;

    private int _value;

    public void Awake()
    {
        if (_score == null)
            throw new NullReferenceException();
    }

    public void OnEnable()
    {
        _score.Changed += ScoreChanged;
    }

    public void OnDisable()
    {
        _score.Changed -= ScoreChanged;
    }

    public void TryLoad(string key)
    {
        if (PlayerPrefs.HasKey(key))
            SetValue(PlayerPrefs.GetInt(key));
        else
            SetValue(0);
    }

    public void TrySave(string key)
    {
        PlayerPrefs.SetInt(key, _value);
    }

    private void ScoreChanged(int value)
    {
        if (value > _value)
            SetValue(value);
    }

    private void SetValue(int value)
    {
        _value = value;
        OnChanged?.Invoke(_value);
    }
}
