using UnityEngine;

public class Pause : MonoBehaviour
{
    // No cap on God bro!
    public bool isPaused;
    public GameObject MoeadaObjt;
    Animator MoedaAnim;
    public BetterSpawner spawner;
    public Player playerScript;
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
            spawner.DeactivateObjects();
            spawner.active = false;
            playerScript.rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        else if(isPaused == true)
        {
            isPaused = false;
            MoedaAnim.speed = 1f;
            spawner.ActivateObjects();
            spawner.active = true;
            playerScript.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
