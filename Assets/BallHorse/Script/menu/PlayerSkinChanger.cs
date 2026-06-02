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
                anim.SetBool("BolicheUni", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightUni", true);
            }
            else if (PowerUpFeched == "Bowling Ball")
            {
                anim.SetBool("BolicheUni", true);
            }
        }

        if (SkinSprite.SelectedSkin == "Alien")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightAlien", false);
                anim.SetBool("BolicheAlien", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightAlien", true);
            }
            else if (PowerUpFeched == "Bowling Ball")
            {
                anim.SetBool("BolicheAlien", true);
            }
        }

        if (SkinSprite.SelectedSkin == "Padrao")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightBola", false);
                anim.SetBool("BolhichePadrao", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightBola", true);
                print("ta mudando");
            }
            else if(PowerUpFeched == "Bowling Ball")
            {
                anim.SetBool("BolhichePadrao", true);
            }
        }

        if (SkinSprite.SelectedSkin == "Chic")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightChic", false);
                anim.SetBool("BolicheChic", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightChic", true);
            }
            else if (PowerUpFeched == "Bowling Ball")
            {
                anim.SetBool("BolicheChic", true);
            }
        }

        if (SkinSprite.SelectedSkin == "Real")
        {
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightReal", false);
                anim.SetBool("BolicheReal", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightReal", true);
            }
            else if (PowerUpFeched == "Bowling Ball")
            {
                anim.SetBool("BolicheReal", true);
            }
        }
    }
}
