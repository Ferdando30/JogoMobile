using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("MyExposedMusic", Mathf.Log10(volume)*20);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFXexposed", Mathf.Log10(volume) *20);
    }
}
