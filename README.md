[日本語の説明はこちら](https://qiita.com/Yamara/private/4caf72e20daea180197d)

# ⚙️SEManager
SEManager is a handy package that allows you to play sound effects without being aware of the AudioSource.
Just install SEManager in your project and write the following code to play sound effects.
``` Sample code.cs
[SerializeField] AudioClip clip;

// Play
clip.TryPlay();
// Set volume, priority, and delay time.
TryPlay(1f, 127, 0.5f);
// Set multiple audio clips, volume, pitch, pitch range, and priority.
new SEClip(clips, 0.5f, 1f, 0.1f, 127).TryPlay();
````

## 🧮 Function

|function name|description|
|-|-|
|audioClip.TryPlay()<br>audioClip.TryPlay(float volume, byte priority, float delay)<br>seClip.TryPlay()<br>seClip.TryPlay(float delay)|Play|
|seClip.Play(AudioSource audioSource)<br>seClip.Play(AudioSource audioSource, float delay)|Play with AudioSource specified|
|SEManager.Stop()|Stop all sound effects|
|SEManager.Pause()|Pause all sound effects|
|SEManager.UnPause()|Unpause all sound effects|
|SEManager.VolumeToDecibel(float volume)|Convert values (range: 0 to 1) to decibels (range: -80 to 0)|
|SEManager.DecibelToVolume(float decibel)|Convert decibels (range: -80 to 0) to values (range: 0 to 1)|

(Some functions are omitted)

## 📝 Notes
The AudioMixerGroup used for SE playback and the maximum number of simultaneous playbacks can be set from SEManager / Resources / SEManagerSettings.asset.

# 💿SEClip
SEClip is a ScriptableObject that can be used to make sound effects less monotonous. When played back with multiple AudioClips and a pitch blur range, the sound effect will sound with a random AudioClip and pitch. This allows for variation in the sound of bullets, footsteps, etc. Playback can be done on SEManager in the same way as with AudioClip.

|variable|description|
|-|-|
|clips|multiple AudioClips|
|priority|priority|
|volume|volume|
|pitch|pitch|pitchRange
|pitch|pitchRange|pitch blur range|

# 🧰 Useful components
The package contains useful components about SEManager and SEClip. Since it is compressed with unitypackage, please expand it when using it.

|component name|description|
|-|-|
|SEVolumeSlider|You can create a volume control slider for sound effects by specifying a Slider, AudioMixer and EventTrigger. Samples can be found in SEManager / Prefabs / SEVolumeSlider.prefab. |SEClipPlayer
|SEClipPlayer|Play SEClip|
|SEClipPlayerForAudioSource|Play SEClip with AudioSource specified|
|SEClipPlayerForAudioSource|Play SEClip by specifying AudioSource| |SEPlayer|Play SEClip by setting it in the inspector| |SEPlayerForAudioSource|Play SEClip by specifying AudioSource
|SEPlayer|Set SEClip in inspector and specify AudioSource to play| |SEPlayerForAudioSource|Set SEClip in inspector and specify AudioSource to play
| AudioClipLoader | Load AudioClip with Preload Audio Data and Load in BackGround disabled |
