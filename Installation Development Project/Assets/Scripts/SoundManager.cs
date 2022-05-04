using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundClass[] sounds;

    public static SoundManager instance;

    void Awake()
    {
        foreach (SoundClass s in sounds)
        {
            s.soundSource = gameObject.AddComponent<AudioSource>();
            s.soundSource.clip = s.clip;
            s.soundSource.volume = s.volume;
            s.soundSource.pitch = s.pitch;
            s.soundSource.loop = s.loop;
        }
    }

    void Start()
    {
        //PlayAudio("Background");
    }

    public void PlayAudio(string name)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.soundSource.Play();
    }
}
