using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;
using Yamara.Audio;

public class SEVolumeSlider : MonoBehaviour
{
    const string KEY_NAME = "SEvolume";

    [SerializeField] Slider slider;
    [SerializeField] AudioMixer mixer;
    [SerializeField] EventTrigger trigger;
    [SerializeField] float defaultVolumeRate = 0.5f;

    float volume;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(KEY_NAME))
        {
            PlayerPrefs.SetFloat(KEY_NAME, defaultVolumeRate);
            PlayerPrefs.Save();
        }

        volume = PlayerPrefs.GetFloat(KEY_NAME);
        slider.value = volume * slider.maxValue;
        FluctVolume(volume);

        slider.onValueChanged.AddListener(value =>
        {
            volume = value / slider.maxValue;
            FluctVolume(volume);
        });

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback.AddListener((eventDate) =>
        {
            PlayerPrefs.SetFloat(KEY_NAME, volume);
            PlayerPrefs.Save();
        });
        trigger.triggers.Add(entry);
    }

    public void FluctVolume(float volume)
    {
        mixer.SetFloat(KEY_NAME, SEManagerBody.VolumeToDecibel(volume));
    }
}