using UnityEngine;
using System;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public event Action OnReloadButtonPressed;
    public event Action OnExitToMenuButtonExit;

    [SerializeField] private SoundController _soundController;
    [SerializeField] private Button _reloadButton;
    [SerializeField] private Button _exitToMenuButton;
    [SerializeField] private SureScreen _sureScreen;
    [SerializeField] private LoseScreen _loseScreen;

    private AcceptResult _acceptResult;
    public void OnEnable()
    {
        _reloadButton.onClick.AddListener(ReloadPressed);
        _exitToMenuButton.onClick.AddListener(ExitPressed);
        _sureScreen.OnChoiseMade += OnChoiseMade;
        _loseScreen.OnPressed += LoseScreenPressed;
    }

    public void OnDisable()
    {
        _reloadButton.onClick.RemoveListener(ReloadPressed);
        _exitToMenuButton.onClick.RemoveListener(ExitPressed);
        _sureScreen.OnChoiseMade -= OnChoiseMade;
        _loseScreen.OnPressed -= LoseScreenPressed;
    }

    private void ReloadPressed()
    {
        _soundController.PlayButtonSound();
        _acceptResult = () => OnReloadButtonPressed?.Invoke();
        _sureScreen.SetText("Do you really want to restart the game?");
        _sureScreen.gameObject.SetActive(true);
    }

    public void ExitPressed()
    {
        _soundController.PlayButtonSound();
        _acceptResult = () => OnExitToMenuButtonExit?.Invoke();
        _sureScreen.SetText("Do you really want to exit?");
        _sureScreen.gameObject.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        _loseScreen.gameObject.SetActive(true);
    }

    private void OnChoiseMade(bool result)
    {
        _soundController.PlayButtonSound();
        _sureScreen.gameObject.SetActive(false);

        if (result)
            _acceptResult();    
    }

    private void LoseScreenPressed()
    {
        _loseScreen.gameObject.SetActive(false);
        OnReloadButtonPressed?.Invoke();
    }

    private delegate void AcceptResult();
}
