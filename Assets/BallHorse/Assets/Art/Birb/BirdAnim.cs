using UnityEngine;

public class BirdAnim : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("BirdAnimation");

    }
}
