using UnityEngine;

public class MusicPlayerTest : MonoBehaviour
{
    public static MusicPlayerTest instance;

    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip musicClip;
    public AudioClip moedaClip;
    public AudioClip powerUpClip;
    public AudioClip powerDownClip;
    public AudioClip puloClip;
    public AudioClip quedaClip;
    public AudioClip stompClip;
    public AudioClip morteClip;
    public AudioClip destruirClip;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void SFXPlay(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}

