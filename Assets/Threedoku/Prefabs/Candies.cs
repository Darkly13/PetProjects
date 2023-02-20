using UnityEngine;
using System;

public class Candies : MonoBehaviour
{
    public static Candies Instant;

    [SerializeField] private Sprite[] _candySprites;

    private int _maxCandiesCount;

    public void Awake()
    {
        if (Instant == null)
            Instant = this;
        else if (Instant == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SetMaxCandiesCount(int value)
    {
        if (value < 2 || value>_candySprites.Length)
            throw new ArgumentOutOfRangeException();
        else
            _maxCandiesCount = value;
    }

    public Sprite GetSprite(int index) => _candySprites[index];
    public int GetRandomCandy() => UnityEngine.Random.Range(1, _maxCandiesCount+1);
}
