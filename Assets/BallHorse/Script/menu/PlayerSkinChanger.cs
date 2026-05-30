using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public Animator anim;
    public static string skin;
    public Pause pauseScript;
    public Player playerScript;

   private void Awake()
    {
        anim = GetComponent<Animator>();

        if (SkinSprite.isUni == true && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("UniClip");
            skin = "unicorn";
            if (playerScript.powerup == "None")
            {
                anim.SetBool("FlightUni", false);
            }
            else if (playerScript.powerup == "Flight")
            {
                anim.SetBool("FlightUni", true);
            }
        }
        else if (SkinSprite.isUni == false && SkinSprite.isAlien == true && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("AlienClip");
            skin = "alien";
            if (playerScript.powerup == "None")
            {
                anim.SetBool("FlightAlien", false);
            }
            else if (playerScript.powerup == "Flight")
            {
                anim.SetBool("FlightAlien", true);
            }
        }
        else if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == true && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("CavaloBolaClip");
            skin = "ballhorse";
            if(playerScript.powerup == "None")
            {
                anim.SetBool("FlightBola", false);
            }
            else if(playerScript.powerup == "Flight")
            {
                anim.SetBool("FlightBola", true);
            }
        }
        else if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == true && SkinSprite.isReal == false)
        {
            anim.Play("ChicleteClip");
            skin = "bubblegum";
            if (playerScript.powerup == "None")
            {
                anim.SetBool("FlightChic", false);
            }
            else if (playerScript.powerup == "Flight")
            {
                anim.SetBool("FlightChic", true);
            }
        }
        else if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == true)
        {
            anim.Play("RealClip");
            skin = "real";
            if (playerScript.powerup == "None")
            {
                anim.SetBool("FlightReal", false);
            }
            else if (playerScript.powerup == "Flight")
            {
                anim.SetBool("FlightReal", true);
            }
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
