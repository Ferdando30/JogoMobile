using UnityEngine;

public class CavaloBolaAnimScript : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("CavaloBolaClip");

    }

    
}
