using Yamara.Audio;

public class SEManager
{
    public static void Stop() => SEManagerBody.Stop();
    public static void Pause() => SEManagerBody.Pause();
    public static void UnPause() => SEManagerBody.UnPause();

    public static float VolumeToDecibel(float volume) => SEManagerBody.VolumeToDecibel(volume);
    public static float DecibelToVolume(float decibel) => SEManagerBody.DecibelToVolume(decibel);
}