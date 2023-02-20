using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioClip _candyPlasedSound;
    [SerializeField] private AudioClip _candiesDisappearedSound;
    [SerializeField] private AudioClip _loseSound;

    private AudioSource _ausioSource;

    public void Awake()
    {
        if (_buttonSound == null)
            throw new NullReferenceException();
        if (_candyPlasedSound == null)
            throw new NullReferenceException();
        if (_candiesDisappearedSound == null)
            throw new NullReferenceException();
        if (_loseSound == null)
            throw new NullReferenceException();

        _ausioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        _ausioSource.PlayOneShot(_buttonSound);
    }

    public void PlayCandeePlasedSound()
    {
        _ausioSource.PlayOneShot(_candyPlasedSound);
    }

    public void PlayCandiesDisappearedSound()
    {
        _ausioSource.PlayOneShot(_candiesDisappearedSound);
    }

    public void PlayLoseSound()
    {
        _ausioSource.PlayOneShot(_loseSound);
    }
}
