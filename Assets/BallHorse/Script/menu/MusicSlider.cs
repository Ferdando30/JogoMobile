using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SfxVolumeKey = "SFXVolume";

    private const string MusicMixerParameter = "MyExposedMusic";
    private const string SfxMixerParameter = "SFXexposed";

    private void Start()
    {
        LoadVolumes();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;

        SetMixerVolume(MusicMixerParameter, volume);

        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;

        SetMixerVolume(SfxMixerParameter, volume);

        PlayerPrefs.SetFloat(SfxVolumeKey, volume);
        PlayerPrefs.Save();
    }
   
    private void LoadVolumes()
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SfxVolumeKey, 1f);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        SetMixerVolume(MusicMixerParameter, musicVolume);
        SetMixerVolume(SfxMixerParameter, sfxVolume);
    }

    private void SetMixerVolume(string parameterName, float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        myMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
    }
}
