using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    [Header("Soundtrack")]
    public AudioSource as_soundtrack1, as_soundtrack2;
    public List<AudioClip> MusicsClips = new List<AudioClip>();
    public List<AudioClip> EffectsClips = new List<AudioClip>();
    public float fadeTime;

    private float length1, length2;
    private bool isFading = false;

    void Awake()
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
    }

    private void Start()
    {
        length1 = as_soundtrack1.clip.length;
        length2 = as_soundtrack2.clip.length;
        Debug.Log(length1);
    }

    private void Update()
    {
      //  Debug.Log(as_soundtrack1.time);


        if ((as_soundtrack1.isPlaying || as_soundtrack2.isPlaying))
        {
            if ((length1 - as_soundtrack1.time < 10f) && !isFading)
            {
                StopAllCoroutines();
                StartCoroutine(FadeSountrack(as_soundtrack1, as_soundtrack2, fadeTime));
                isFading = true;
            }
            if ((length2 - as_soundtrack2.time < 10f) && as_soundtrack1.isPlaying && !isFading)
            {
                StopAllCoroutines();
                StartCoroutine(FadeSountrack(as_soundtrack2, as_soundtrack1, fadeTime));
                isFading = true;
            }
        }
    }

    public void StopMusic()
    {
        StopAllCoroutines();
        as_soundtrack1.Stop();
        as_soundtrack2.Stop();
    }

    public void PlayMusic()
    {
        StopAllCoroutines();
        as_soundtrack1.mute = false;
        as_soundtrack1.Play();
    }

    private IEnumerator FadeSountrack(AudioSource s1, AudioSource s2, float t)
    {
        if (!s1.mute)
        {
            s2.mute = false;
            s2.volume = 0.3f;
            s2.Play();
            while (t > 0)
            {
                yield return null;
                t -= Time.deltaTime;
                s2.volume += Time.deltaTime / t;
                s1.volume -= Time.deltaTime / t;
            }
            s1.mute = true;
            s1.Stop();
            isFading = false;
        }
        yield break;
    }

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
