using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    // No cap on God bro!
    public bool isPaused;
    public GameObject MoeadaObjt;
    Animator MoedaAnim;
    public BetterSpawner spawner;
    public Player playerScript;
    public GameObject PausedImg;
    public Slider musicSlider;
    public Button Replay;
    public Button OptionsBtn;
    public Button Home;
    public Button BackBtn;

    void Awake()
    {
        isPaused = false;
        MoedaAnim = MoeadaObjt.GetComponent<Animator>();
        PausedImg.SetActive(false);
        musicSlider.gameObject.SetActive(false);
        BackBtn.gameObject.SetActive(false);
    }

    public void Pausando()
    {
            isPaused = true;
            MoedaAnim.speed = 0f;
            spawner.DeactivateObjects();
            spawner.active = false;
            playerScript.rb.constraints = RigidbodyConstraints2D.FreezePosition;
        PausedImg.SetActive(true);

    }
    public void DesPausando()
    {
        isPaused = false;
        MoedaAnim.speed = 1f;
        spawner.ActivateObjects();
        spawner.active = true;
        playerScript.rb.linearVelocity = Vector2.zero;
        playerScript.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        PausedImg.SetActive(false);
        musicSlider.gameObject.SetActive(false);
        BackBtn.gameObject.SetActive(false);
    }

    public void Options()
    {
        musicSlider.gameObject.SetActive(true);
        Replay.gameObject.SetActive(false);
        OptionsBtn.gameObject.SetActive(false);
        Home.gameObject.SetActive(false);
        BackBtn.gameObject.SetActive(true);
    }
    
    public void Back()
    {
        musicSlider.gameObject.SetActive(false);
        Replay.gameObject.SetActive(true);
        OptionsBtn.gameObject.SetActive(true);
        Home.gameObject.SetActive(true);
        BackBtn.gameObject.SetActive(false);
    }
}
