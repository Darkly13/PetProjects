using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameField _gameField;
    [SerializeField] private CandiesChoser _candiesChoser;
    [SerializeField] private Score _score;
    [SerializeField] private HighScore _highScore;
    [SerializeField] private HUD _hud;
    [SerializeField] private Menu _menu;
    [SerializeField] private Saver _saver;
    [SerializeField] private InputController _inputController;
    [SerializeField] private SoundController _soundController;
    [SerializeField] private Admob _admob;

    private FieldInfo _currentInfo;
    private Gameplay _gameplay;

    public void Awake()
    {
        _menu.OnStartButtonPressedEvent += StartGame;
        _hud.OnReloadButtonPressed += Reload;
        _hud.OnExitToMenuButtonExit += ExitToMenu;
        _inputController.OnEscapeButtonPressed += EscapeButtonPressed;
        _inputController.OnHomeButtonPressed += HomeButtonPressed;
    }

    public void OnDisable()
    {
        _menu.OnStartButtonPressedEvent -= StartGame;
        _hud.OnReloadButtonPressed -= Reload;
        _hud.OnExitToMenuButtonExit -= ExitToMenu;
        _inputController.OnEscapeButtonPressed -= EscapeButtonPressed;
        _inputController.OnHomeButtonPressed -= HomeButtonPressed;
    }

    private void StartGame(FieldInfo info)
    {
        _currentInfo = info;
        Candies.Instant.SetMaxCandiesCount(info.CandiesCount);
        _gameField.Init(info.FieldSize.x, info.FieldSize.y);
        TryLoad();
        _gameplay = new Gameplay(_gameField, _candiesChoser, _score, _soundController);
        _gameplay.OnTurnsLost += TurnsLost;
        _gameplay.Start();
    }

    private void TryLoad()
    {
        _highScore.TryLoad(_currentInfo.name);
        if(_saver.TryLoad(_currentInfo.name, out FieldSave save))
        {
            _gameField.Set(save.Cells);
            _score.Add(save.Score);
        }
    }

    private void TrySave()
    {
        _highScore.TrySave(_currentInfo.name);
        _saver.TrySave(_gameField.Cells, _score.Value, _currentInfo.name);
    }

    private void ExitToMenu()
    {
        TrySave();
        _gameplay.Stop();
        _menu.gameObject.SetActive(true);
    }

    private void Reload()
    {
        _highScore.TrySave(_currentInfo.name);
        _gameplay.Restart();
        _admob.ShowAd();
    }

    private void EscapeButtonPressed()
    {
        if (_menu.gameObject.activeInHierarchy)
            Application.Quit();
        else
            _hud.ExitPressed();
    }

    private void HomeButtonPressed()
    {
        TrySave();
        Application.Quit();
    }

    private void TurnsLost()
    {
        _admob.ShowAd();
        _hud.ShowLoseScreen();
    }
}
