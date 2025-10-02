using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [Header("Sound Effects")]
    [SerializeField] private AudioClip _moveRock;
    [SerializeField] private AudioClip _nloMoveRoc;


    [Header("Music")]
    [SerializeField] private AudioClip _soundtrack;

    private AudioSource _sfxSource;
    private AudioSource _musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (_sfxSource == null)
            _sfxSource = gameObject.AddComponent<AudioSource>();

        if (_musicSource == null)
            _musicSource = gameObject.AddComponent<AudioSource>();

        _musicSource.loop = true;
    }
    public void PlaySound(int index)
    {
        AudioClip clip = index switch
        {
            1 => _moveRock,
            2 => _nloMoveRoc,
            
        };

        if (clip != null)
            _sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic()
    {
        _musicSource.clip = _soundtrack;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
}