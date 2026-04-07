using UnityEngine;

public class CavaloColina : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        anim = GetComponent<Animator>();

        anim.Play("cavalonacolinaanimacaoidol_Clip");
    }

    
}
