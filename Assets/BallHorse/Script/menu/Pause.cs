using UnityEngine;

public class Pause : MonoBehaviour
{
    // No cap on God bro!
    public bool isPaused;
    public GameObject MoeadaObjt;
    Animator MoedaAnim;
    void Awake()
    {
        isPaused = false;
        MoedaAnim = MoeadaObjt.GetComponent<Animator>();
    }

    public void Pausando()
    {
        if(isPaused == false)
        {
            isPaused = true;
            MoedaAnim.speed = 0f;
        }

        else if(isPaused == true)
        {
            isPaused = false;
            MoedaAnim.speed = 1f;
        }
    }
}
