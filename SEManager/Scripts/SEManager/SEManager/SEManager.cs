using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

namespace Yamara.Audio
{
    public class SEManager : MonoBehaviour
    {
        private static IEnumerable<AudioSource> audioSources = new List<AudioSource>();

        private static SEManagerSettings setings;

        // Generate SEManager on awake
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Generate()
        {
            SEManager seManager = Instantiate(Resources.Load<SEManager>("SEManager"));
            seManager.name = "SEManager";
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            setings = Resources.Load<SEManagerSettings>("SEManagerSettings");

            List<AudioSource> audios = new List<AudioSource>();
            AudioSource audioSource = Resources.Load<AudioSource>("SEAudioSource");

            for (int i = 0; i < setings.AudioSourceCount; i++)
            {
                AudioSource audio = Instantiate(audioSource);
                audio.transform.SetParent(gameObject.transform);
                audio.playOnAwake = false;
                audio.priority = byte.MaxValue;
                audios.Add(audio);
                DontDestroyOnLoad(audio.gameObject);
            }
            audioSources = audios;
        }

        private void Update()
        {
            // Set lowest priority when Play() is completed
            foreach (var item in audioSources)
            {
                if (item.isPlaying) continue;
                item.priority = byte.MaxValue;
            }
        }

        #region Play
        public static void Play(AudioClip se, float volume = 1f, byte priority = 0)
        {
            Play(audioSources.First(), se, volume, priority);
            audioSources = audioSources.OrderByDescending(x => x.priority);
        }
        public static void Play(AudioSource audioSource, AudioClip clip, float volume = 1f, byte priority = 0)
        {
            audioSource.clip = clip;
            audioSource.priority = priority;
            audioSource.volume = volume;
            audioSource.pitch = 1f;
            audioSource.Play();
        }

        public static void PlayDelayed(AudioClip se, float delay, float volume = 1f, byte priority = 0)
        {
            PlayDelayed(audioSources.First(), se, delay, volume, priority);
            audioSources = audioSources.OrderByDescending(x => x.priority);
        }
        public static void PlayDelayed(AudioSource audioSource, AudioClip clip, float delay = 0f, float volume = 1f, byte priority = 0)
        {
            audioSource.clip = clip;
            audioSource.priority = priority;
            audioSource.volume = volume;
            audioSource.pitch = 1f;
            audioSource.PlayDelayed(delay);
        }

        public static void Play(SEClip se)
        {
            if (se.priority > audioSources.First().priority) return;
            Play(audioSources.First(), se);
            audioSources = audioSources.OrderByDescending(x => x.priority);
        }
        public static void Play(AudioSource audioSource, SEClip se)
        {
            audioSource.clip = se.clips[Random.Range(0, se.clips.Length)];
            audioSource.priority = se.priority;
            audioSource.volume = se.volume;
            audioSource.pitch = se.pitch + Random.Range(-se.pitchRange, se.pitchRange);
            audioSource.Play();
        }

        public static void PlayDelayed(SEClip se, float delay)
        {
            if (se.priority > audioSources.First().priority) return;
            PlayDelayed(audioSources.First(), se, delay);
            audioSources = audioSources.OrderByDescending(x => x.priority);
        }
        public static void PlayDelayed(AudioSource audioSource, SEClip se, float delay)
        {
            audioSource.clip = se.clips[Random.Range(0, se.clips.Length)];
            audioSource.priority = se.priority;
            audioSource.volume = se.volume;
            audioSource.pitch = se.pitch + Random.Range(-se.pitchRange, se.pitchRange);
            audioSource.PlayDelayed(delay);
        }
        #endregion

        #region Stop
        public static void Stop()
        {
            foreach (var item in audioSources)
            {
                item.clip = null;
                if (!item.isPlaying) continue;
                item.Stop();
                item.priority = byte.MaxValue;
            }
        }
        public static void Pause()
        {
            foreach (var item in audioSources)
            {
                if (!item.isPlaying)
                {
                    item.clip = null;
                    continue;
                }
                item.Pause();
            }
        }
        public static void UnPause()
        {
            foreach (var item in audioSources)
            {
                if (item.isPlaying) continue;
                item.UnPause();
                item.priority = byte.MaxValue;
            }
        }
        #endregion

        #region Utility
        public static float VolumeToDecibel(float volume)
        {
            return Mathf.Clamp(20f * Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)), -80f, 0f);
        }
        public static float DecibelToVolume(float decibel)
        {
            return Mathf.Clamp(Mathf.Pow(10f, Mathf.Clamp(decibel, -80f, 0f) * 0.05f), 0f, 1f);
        }
        #endregion
    }
}