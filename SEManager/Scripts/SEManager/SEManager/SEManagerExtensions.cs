using UnityEngine;
using Yamara.Audio;

public static class SEManagerExtensions
{
    public static void Play(this AudioClip clip) => SEManager.Play(clip);
    public static void Play(this AudioClip clip, byte priority = 0, float volume = 1f) => SEManager.Play(clip, volume, priority);
    public static void Play(this AudioClip clip, float volume = 1f, byte priority = 0) => SEManager.Play(clip, volume, priority);

    public static void PlayDelayed(this AudioClip clip, float delay) => SEManager.PlayDelayed(clip, delay);
    public static void PlayDelayed(this AudioClip clip, float delay, byte priority = 0, float volume = 1f) => SEManager.PlayDelayed(clip, delay, volume, priority);
    public static void PlayDelayed(this AudioClip clip, float delay, float volume = 1f, byte priority = 0) => SEManager.PlayDelayed(clip, delay, volume, priority);

    public static void Play(this SEClip clip) => SEManager.Play(clip);
    public static void PlayDelayed(this SEClip clip, float delay) => SEManager.PlayDelayed(clip, delay);

    public static void Play(this AudioSource audioSource, SEClip clip) => SEManager.Play(audioSource, clip);
    public static void PlayDelayed(this AudioSource audioSource, SEClip clip, float delay) => SEManager.PlayDelayed(audioSource, clip, delay);
}