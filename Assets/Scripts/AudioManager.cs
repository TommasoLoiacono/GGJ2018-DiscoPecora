using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public List<AudioClip> MusicsClips = new List<AudioClip>();
    public List<AudioClip> EffectsClips = new List<AudioClip>();

    private AudioClip _currentEffectsClip;

    public AudioClip CurrentEffectsClip
    {
        get { return _currentEffectsClip; }
        set
        {
            _currentEffectsClip = value;
            EffectsSource.clip = _currentEffectsClip;
        }
    }

    private AudioClip _currentMusicClip;

    public AudioClip CurrentMusicClip
    {
        get { return _currentEffectsClip; }
        set
        {
            _currentMusicClip = value;
            MusicSource.clip = _currentMusicClip;
        }
    }

    AudioSource MusicSource;
    AudioSource EffectsSource;

    public void Init()
    {
        AudioSource[] tempList = GetComponentsInChildren<AudioSource>();
        MusicSource = tempList[0];
        EffectsSource = tempList[1];
    }

}
