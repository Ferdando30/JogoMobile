using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider mySlider;

    public void SetMusicVolume()
    {
        float volume = mySlider.value;
        myMixer.SetFloat("MyExposedMusic", Mathf.Log10(volume)*20);
    }
}
