using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundScript : MonoBehaviour
{
    
    public AudioClip CoinSound;
    public AudioClip FailureSound;
    public AudioClip BonusSound;

    public AudioSource audioSource;
    public AudioSource gamePlayAudioSource;

     private static GameSoundScript _gameSoundManager;

    public static GameSoundScript gameSoundManager { get { return _gameSoundManager; } }

    void Awake()
    {

        if (_gameSoundManager == null)
        {
            _gameSoundManager = this;
        }
        //panel=GameObject.FindGameObjectWithTag("Panel");
    }

    public void CoinPlay()
    {
        audioSource.clip=CoinSound;
        audioSource.Play();
    }

    public void FailurePlay()
    {
        audioSource.clip=FailureSound;
        audioSource.Play();
    }

    public void PauseGamePlay()
    {
        gamePlayAudioSource.Pause();
    }

    public void ResumeGamePlay()
    {
        gamePlayAudioSource.Play();
    }

    public void BonusPlay()
    {
        audioSource.clip=BonusSound;
        audioSource.Play();
    }

}
