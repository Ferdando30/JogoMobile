using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public Animator anim;
    public static string skin;
    public Pause pauseScript;

   private void Awake()
    {
        anim = GetComponent<Animator>();

        if (SkinSprite.isUni == true && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
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
    public void Update()
    {
        if (pauseScript.isPaused == false)
        {
            anim.speed = 1f;
        }
        else
        {
            anim.speed = 0f;
        }
    }

    
}
