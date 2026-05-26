using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public Animator anim;
    public static string skin;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        if(SkinSprite.isUni == true && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("UniClip");
            skin = "unicorn";
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == true && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("AlienClip");
            skin = "alien";
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == true && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("CavaloBolaClip");
            skin = "ballhorse";
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == true && SkinSprite.isReal == false)
        {
            anim.Play("ChicleteClip");
            skin = "bubblegum";
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == true)
        {
            anim.Play("RealClip");
            skin = "real";
        }
    }

    
}
