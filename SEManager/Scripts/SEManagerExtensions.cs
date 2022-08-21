using UnityEngine;

namespace Yamara.Audio
{
    public static class SEManagerExtensions
    {
        public static bool Play(this AudioClip clip, float delay = 0f)
            => SEManager.Play(clip, delay);
        public static bool Play(this AudioClip clip, float volume = 1f, byte priority = 0, float delay = 0f)
            => SEManager.Play(clip, volume, priority, delay);

        public static bool Play(this SEClip clip, float delay = 0f)
            => SEManager.Play(clip, delay);

        public static void Play(this AudioSource audioSource, SEClip clip, float delay = 0f)
            => SEManager.Play(audioSource, clip, delay);
    }
}