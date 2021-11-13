using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Create SEClip")]
[Serializable]
public class SEClip : ScriptableObject
{
    public AudioClip[] clips = null;
    [SerializeField, Range(0, byte.MaxValue)] public byte priority = byte.MaxValue / 2;
    [SerializeField, Range(0f, 1f)] public float volume = 1f;
    [SerializeField] public float pitch = 1f, pitchRange;

    public SEClip()
    {
        this.clips = null;
        this.priority = byte.MaxValue;
        this.volume = 1f;
        this.pitch = 1f;
        this.pitchRange = 0f;
    }
    public SEClip(SEClip seClip)
    {
        this.clips = seClip.clips;
        this.priority = seClip.priority;
        this.volume = seClip.volume;
        this.pitch = seClip.pitch;
        this.pitchRange = seClip.pitchRange;
    }

    public SEClip(AudioClip clip)
    {
        this.clips = new AudioClip[] { clip };
        this.priority = byte.MaxValue;
        this.volume = 1f;
        this.pitch = 1f;
        this.pitchRange = 0f;
    }
    public SEClip(AudioClip clip = null, float volume = 1f, float pitch = 1f, float pitchRange = 0f, byte priority = 0)
    {
        this.clips = new AudioClip[] { clip };
        this.priority = priority;
        this.volume = volume;
        this.pitch = pitch;
        this.pitchRange = pitchRange;
    }
    public SEClip(AudioClip clip = null, byte priority = 0, float volume = 1f, float pitch = 1f, float pitchRange = 0f)
    {
        this.clips = new AudioClip[] { clip };
        this.priority = priority;
        this.volume = volume;
        this.pitch = pitch;
        this.pitchRange = pitchRange;
    }
    public SEClip(AudioClip[] clips)
    {
        this.clips = clips;
        this.priority = byte.MaxValue;
        this.volume = 1f;
        this.pitch = 1f;
        this.pitchRange = 0f;
    }
    public SEClip(AudioClip[] clips = null, float volume = 1f, float pitch = 1f, float pitchRange = 0f, byte priority = 0)
    {
        this.clips = clips;
        this.priority = priority;
        this.volume = volume;
        this.pitch = pitch;
        this.pitchRange = pitchRange;
    }
    public SEClip(AudioClip[] clips = null, byte priority = 0, float volume = 1f, float pitch = 1f, float pitchRange = 0f)
    {
        this.clips = clips;
        this.priority = priority;
        this.volume = volume;
        this.pitch = pitch;
        this.pitchRange = pitchRange;
    }
}