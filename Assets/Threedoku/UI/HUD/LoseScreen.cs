using UnityEngine;
using System;

public class LoseScreen : MonoBehaviour
{
    public event Action OnPressed;

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
            OnPressed?.Invoke();
    }
}
