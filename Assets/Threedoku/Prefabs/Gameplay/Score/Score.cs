using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action<int> Changed;

    public int Value { get; private set; }

    public void Awake()
    {
        Value = 0;
        Changed?.Invoke(Value);
    }

    public void Add(int score)
    {
        if (score < 0)
            throw new ArgumentOutOfRangeException();
        Value += score;
        Changed?.Invoke(Value);
    }

    public void Clear()
    {
        Value = 0;
        Changed?.Invoke(Value);
    }
}
