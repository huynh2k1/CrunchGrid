using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager I;
    public AudioSource _sourceMusic;
    public AudioClip musicAudio;

    public AudioSource[] _sourceSounds;
    private Queue<AudioSource> queue_sources;

    public AudioClip Click;
    public AudioClip Complete;
    public AudioClip Hit;
    public AudioClip Unlock;
    public AudioClip Win;

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        queue_sources = new Queue<AudioSource>(_sourceSounds);
        LoadVolumeMusic();
        PlayMusic();
    }

    void PlayMusic()
    {
        _sourceMusic.clip = musicAudio;
        _sourceMusic.Play();
    }

    public void SaveLoadVolume()
    {
        LoadVolumeSounds();
        LoadVolumeMusic();
    }

    void LoadVolumeSounds()
    {
        foreach (var sound in _sourceSounds)
        {
            //sound.volume = PlayerPrefData.SoundVolume;
        }
    }

    void LoadVolumeMusic()
    {
        //_sourceMusic.volume = PlayerPrefData.MusicVolume;
    }


    public void PlayAudioType(TypeAudio type)
    {
        switch (type)
        {
            case TypeAudio.CLICK:
                PlayAudio(Click);
                break;
            case TypeAudio.STICKCOMPLETE:
                PlayAudio(Complete);
                break;
            case TypeAudio.HIT:
                PlayAudio(Hit);
                break;
            case TypeAudio.STICKUNLOCK:
                PlayAudio(Unlock);
                break;
            case TypeAudio.WIN:
                PlayAudio(Win);
                break;
        }
    }

    void PlayAudio(AudioClip clip)
    {
        var source = queue_sources.Dequeue();
        if (source == null)
            return;
        source.PlayOneShot(clip);
        queue_sources.Enqueue(source);
    }

}

public enum TypeAudio
{
    CLICK,
    STICKCOMPLETE,
    HIT,
    WIN,
    STICKUNLOCK
}