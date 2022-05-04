using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundClass
{
    public string name;
    public AudioClip clip;
    public bool loop;

    [Range(0.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float volume;

    [HideInInspector]
    public AudioSource soundSource;
}
