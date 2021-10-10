[日本語の説明はこちら](https://qiita.com/Yamara/private/4caf72e20daea180197d)

# ⚙️SEManager
SEManager is a handy package that allows you to play sound effects without being aware of the AudioSource.
Once SEManager is installed in your project, it will be automatically generated when the game is run.

``` Sample code.cs
// Play
clip.Play();
// Set volume, priority, and delay time.
PlayDelayed(1f, 0.5f, 127);
// Set multiple audio clips, volume, pitch, pitch range, and priority.
new SEClip(clips, 0.5f, 1f, 0.1f, 127).Play();
````

## 🧮 Function

|function name|description|
|-|-|
|Play(AudioClip se)<br>Play(SEClip se)|Play|
|Play(AudioSource audioSource, SEClip se)|Play with AudioSource specified|
|PlayDelayed(AudioClip se, float delay)<br>PlayDelayed(SEClip se, float delay)|Delayed playback|
|PlayDelayed(AudioSource audioSource, SEClip se, float delay)|Play delayed with AudioSource specified|
|Stop()|Stop all sound effects|
|Pause()|Pause all sound effects|
|UnPause()|unpause all sound effects|

(Some functions are omitted)

We have extension methods "SEManagerExtensions" for AudioClip and AudioSource. Of the above functions, you can handle the Play system functions with ease.

## 📝 Notes

You can change the maximum number of simultaneous plays from SEManager / Resources / SEManagerSettings.asset.
You can change the volume from SEManager / SEAudioMixer.mixer (for playback with AudioSource specified, specify SEAudioMixer for AudioMixer).
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
The package contains some useful components related to SEManager and SEClip.

|component name|description|
|-|-|
|SEVolumeSlider|You can create a volume control slider for sound effects by specifying a Slider, AudioMixer and EventTrigger. Samples can be found in SEManager / Prefabs / SEVolumeSlider.prefab. |SEClipPlayer
|SEClipPlayer|Play SEClip|
|SEClipPlayerForAudioSource|Play SEClip with AudioSource specified|
|SEClipPlayerForAudioSource|Play SEClip by specifying AudioSource| |SEPlayer|Play SEClip by setting it in the inspector| |SEPlayerForAudioSource|Play SEClip by specifying AudioSource
|SEPlayer|Set SEClip in inspector and specify AudioSource to play| |SEPlayerForAudioSource|Set SEClip in inspector and specify AudioSource to play
| AudioClipLoader | Load AudioClip with Preload Audio Data and Load in BackGround disabled |
