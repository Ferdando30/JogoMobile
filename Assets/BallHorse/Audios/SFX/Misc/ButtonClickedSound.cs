using UnityEngine;

public class ButtonClickedSound : MonoBehaviour
{
    MusicPlayerTest audioScript;
    void Awake()
    {
        audioScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<MusicPlayerTest>();
    }

    public void foiClicado()
    {
        audioScript.SFXPlay(audioScript.buttonClickClip);
    }
}
