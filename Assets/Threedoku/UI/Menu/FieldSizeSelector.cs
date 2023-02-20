using UnityEngine;

public class FieldSizeSelector : MonoBehaviour
{
    [SerializeField] private SoundController _soundController;

    public FieldInfo CurrentInfo => _currentInfo;
    private FieldInfo _currentInfo;

    public void OnEnable()
    {
        FieldSizeToggle.OnPicked += SizePicked;
    }

    public void OnDisable()
    {
        FieldSizeToggle.OnPicked -= SizePicked;
    }

    private void SizePicked(FieldInfo info)
    {
        _soundController.PlayButtonSound();
        _currentInfo = info;
    }
}
