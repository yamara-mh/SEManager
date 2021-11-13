using UnityEngine;
using Yamara.Audio;

public static class SEManagerExtensions
{
    public static void Play(this AudioClip clip) => SEManagerBody.Play(clip);
    public static void Play(this AudioClip clip, byte priority = 0, float volume = 1f) => SEManagerBody.Play(clip, volume, priority);
    public static void Play(this AudioClip clip, float volume = 1f, byte priority = 0) => SEManagerBody.Play(clip, volume, priority);

    public static void PlayDelayed(this AudioClip clip, float delay) => SEManagerBody.PlayDelayed(clip, delay);
    public static void PlayDelayed(this AudioClip clip, float delay, byte priority = 0, float volume = 1f) => SEManagerBody.PlayDelayed(clip, delay, volume, priority);
    public static void PlayDelayed(this AudioClip clip, float delay, float volume = 1f, byte priority = 0) => SEManagerBody.PlayDelayed(clip, delay, volume, priority);

    public static void Play(this SEClip clip) => SEManagerBody.Play(clip);
    public static void PlayDelayed(this SEClip clip, float delay) => SEManagerBody.PlayDelayed(clip, delay);

    public static void Play(this AudioSource audioSource, SEClip clip) => SEManagerBody.Play(audioSource, clip);
    public static void PlayDelayed(this AudioSource audioSource, SEClip clip, float delay) => SEManagerBody.PlayDelayed(audioSource, clip, delay);
}