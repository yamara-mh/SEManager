using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

namespace Yamara.Audio
{
    [DefaultExecutionOrder(-100)]
    public class SEManager : MonoBehaviour
    {
        public static SEManager Instance { get; private set; }

        private static List<AudioSource> _audioSources = new List<AudioSource>();

        private static int _lowestPriority;

        // Generate SEManager on awake
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Generate()
        {
            var seManager = new GameObject().AddComponent<SEManager>();
            seManager.name = "SEManager";
            Instance = seManager;
            DontDestroyOnLoad(Instance.gameObject);

            var setings = Resources.Load<SEManagerSettings>("SEManagerSettings");

            for (int i = 0; i < setings.AudioSourceCount; i++)
            {
                var audioSource = Instance.gameObject.AddComponent<AudioSource>();
                audioSource.transform.SetParent(Instance.transform);

                audioSource.outputAudioMixerGroup = setings.AudioMixerGroup;
                audioSource.playOnAwake = false;
                audioSource.priority = byte.MaxValue;
                audioSource.reverbZoneMix = 0f;
                audioSource.dopplerLevel = 0f;
                _audioSources.Add(audioSource);
            }
        }

        private void Update()
        {
            foreach (var item in _audioSources)
            {
                if (item.isPlaying) continue;
                item.priority = byte.MaxValue;
                _lowestPriority = byte.MaxValue;
            }
        }

        #region Play

        public static bool TryPlay(
            AudioClip se,
            float volume = 1f,
            byte priority = 0,
            float delay = 0f)
        {
            if (priority > _lowestPriority) return false;
            Play(_audioSources.First(audio => audio.priority == _lowestPriority),
                se,
                volume,
                priority,
                delay);
            _lowestPriority = _audioSources.Max(audio => audio.priority);
            return true;
        }
        public static bool TryPlay(SEClip se, float delay = 0f)
        {
            if (se.priority > _lowestPriority) return false;
            Play(_audioSources.First(audio => audio.priority == _lowestPriority), se, delay);
            _lowestPriority = _audioSources.Max(audio => audio.priority);
            return true;
        }

        public static void Play(
            AudioSource audioSource,
            AudioClip clip,
            float volume = 1f,
            byte priority = 0,
            float delay = 0f)
        {
            audioSource.clip = clip;
            audioSource.priority = priority;
            audioSource.volume = volume;
            audioSource.pitch = 1f;
            audioSource.PlayDelayed(delay);
        }

        public static void Play(AudioSource audioSource, SEClip se, float delay = 0f)
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
            foreach (var item in _audioSources)
            {
                item.clip = null;
                if (!item.isPlaying) continue;
                item.Stop();
                item.priority = byte.MaxValue;
                _lowestPriority = byte.MaxValue;
            }
        }
        public static void Pause()
        {
            foreach (var item in _audioSources)
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
            foreach (var item in _audioSources)
            {
                if (item.isPlaying) continue;
                item.UnPause();
                item.priority = byte.MaxValue;
            }
        }
        #endregion

        public static float VolumeToDecibel(float volume) => Mathf.Clamp(20f * Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)), -80f, 0f);
        public static float DecibelToVolume(float decibel) => Mathf.Clamp(Mathf.Pow(10f, Mathf.Clamp(decibel, -80f, 0f) * 0.05f), 0f, 1f);
    }
}