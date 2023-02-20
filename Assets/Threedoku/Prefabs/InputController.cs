using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public event Action OnEscapeButtonPressed;
    public event Action OnHomeButtonPressed;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnEscapeButtonPressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.Home))
            OnHomeButtonPressed?.Invoke();
    }
}
