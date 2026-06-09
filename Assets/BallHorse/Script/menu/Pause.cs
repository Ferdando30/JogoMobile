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
    void Awake()
    {
        isPaused = false;
        MoedaAnim = MoeadaObjt.GetComponent<Animator>();
        PausedImg.SetActive(false);
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
        playerScript.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        PausedImg.SetActive(false);
    }
}
