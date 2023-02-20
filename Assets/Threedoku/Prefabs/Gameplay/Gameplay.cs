using System;

public class Gameplay
{
    public event Action OnTurnsLost;

    private GameField _gameField;
    private RandomCandiesSpawner _randomCandiesSpawner;
    private MatchChecker _matchChecker;
    private CandiesChoser _candiesChoser;
    private Score _score;
    private SoundController _soundController;

    public Gameplay(GameField gameField, CandiesChoser candiesChoser, Score score, SoundController soundController)
    {
        _gameField = gameField;
        _candiesChoser = candiesChoser;
        _score = score;
        _soundController = soundController;

        _randomCandiesSpawner = new RandomCandiesSpawner(_gameField.Cells);
        _matchChecker = new MatchChecker(_gameField.Cells);

        _gameField.OnCellPickedEvent += OnCellPicked;
    }

    public void Start()
    {
        _candiesChoser.Enable();
        _randomCandiesSpawner.UpdateFreeList();
        if (!_gameField.Isloaded)
        {
            _randomCandiesSpawner.TrySpawn();
            _randomCandiesSpawner.TrySpawn();
        }
    }

    public void Restart()
    {
        _gameField.Clear();
        _score.Clear();
        Start();
    }

    public void Stop()
    {
        _gameField.Delete();
        _candiesChoser.Disable();
        _score.Clear();
        _gameField.OnCellPickedEvent -= OnCellPicked;
    }


    private void OnCellPicked(Cell cell)
    {
        if(cell.IsEmpty && _candiesChoser.Picked != null)
        {
            _soundController.PlayCandeePlasedSound();
            cell.SetValue(_candiesChoser.Picked.Value);
            TryMatch(cell);
            _candiesChoser.CreateRandomCandy();
            _randomCandiesSpawner.UpdateFreeList();
            TryMakeTurn();
        }
    }

    private void TryMatch(Cell cell)
    {
        if (_matchChecker.TryMatch((FieldCell)cell, out int count))
        {
            _soundController.PlayCandiesDisappearedSound();
            _randomCandiesSpawner.UpdateFreeList();
            AddMatchedScore(count);
        } 
    }

    private void AddMatchedScore(int matchCount)
    {
        int extra = matchCount - 3;
        int score = 3 + extra * extra;
        _score.Add(score);
    }

    private void TryMakeTurn()
    {
        if (_randomCandiesSpawner.TrySpawn(out FieldCell cell))
        {
            TryMatch(cell);
            if(_randomCandiesSpawner.FreeCount<=0)
            {
                _soundController.PlayLoseSound();
                OnTurnsLost?.Invoke();
            }
        }
        else
        {
            _soundController.PlayLoseSound();
            OnTurnsLost?.Invoke();
        }
    }
}
