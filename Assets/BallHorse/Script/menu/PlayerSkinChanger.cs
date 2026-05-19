using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        anim = GetComponent<Animator>();
        if(SkinSprite.isUni == true && SkinSprite.isAlien == false)
        {
            anim.Play("UniClip");
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == true)
        {
            anim.Play("AlienClip");
        }
    }

    
}
