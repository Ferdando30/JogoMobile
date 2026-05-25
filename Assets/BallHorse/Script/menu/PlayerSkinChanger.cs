using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        anim = GetComponent<Animator>();
        if(SkinSprite.isUni == true && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("UniClip");
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == true && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("AlienClip");
           
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == true && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("CavaloBolaClip");
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == true && SkinSprite.isReal == false)
        {
            anim.Play("ChicleteClip");
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == true)
        {
            anim.Play("RealClip");
        }
    }

    
}
