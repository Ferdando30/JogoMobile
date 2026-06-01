using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public Animator anim;
    public static string skin;
    public Pause pauseScript;
    private Player playerScript;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerScript = GetComponent<Player>();
   
        if (SkinSprite.SelectedSkin == "Uni")
        {
            anim.Play("UniClip");
            skin = "unicorn";
        }
        else if (SkinSprite.SelectedSkin == "Alien")
        {
            anim.Play("AlienClip");
            skin = "alien";
        }
        else if (SkinSprite.SelectedSkin == "Padrao")
        {
            anim.Play("CavaloBolaClip");
            skin = "ballhorse";
        }
        else if (SkinSprite.SelectedSkin == "Chic")
        {
            anim.Play("ChicleteClip");
            skin = "bubblegum";
        }
        else if (SkinSprite.SelectedSkin == "Real")
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

        string PowerUpFeched = playerScript.powerup;
        //Debug.Log("Fetched string is: " + PowerUpFeched);

        if (SkinSprite.SelectedSkin == "Uni")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightUni", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightUni", true);
            }
        }

        if (SkinSprite.SelectedSkin == "Alien")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightAlien", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightAlien", true);
            }
        }

        if (SkinSprite.SelectedSkin == "Padrao")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightBola", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightBola", true);
                print("ta mudando");
            }
        }

        if (SkinSprite.SelectedSkin == "Chic")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightChic", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightChic", true);
            }
        }

        if (SkinSprite.SelectedSkin == "Real")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightReal", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightReal", true);
            }
        }
    }
}
