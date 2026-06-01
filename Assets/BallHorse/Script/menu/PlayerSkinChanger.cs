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
        string PowerUpFeched = playerScript.powerup;
        Debug.Log("Fetched string is: " + PowerUpFeched);

        if (SkinSprite.SelectedSkin == "Uni")
        {
            anim.Play("UniClip");
            skin = "unicorn";
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightUni", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightUni", true);
            }
        }
        else if (SkinSprite.SelectedSkin == "Alien")
        {
            anim.Play("AlienClip");
            skin = "alien";
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightAlien", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightAlien", true);
            }
        }
        else if (SkinSprite.SelectedSkin == "Padrao")
        {
            anim.Play("CavaloBolaClip");
            skin = "ballhorse";
            if(PowerUpFeched == "None")
            {
                anim.SetBool("FlightBola", false);
            }
            else if(PowerUpFeched.Equals("Flight"))
            {
                anim.SetBool("FlightBola", true);
                print("deu certo");
            }
        }
        else if (SkinSprite.SelectedSkin == "Chic")
        {
            anim.Play("ChicleteClip");
            skin = "bubblegum";
            if (PowerUpFeched == "None")
            {
                anim.SetBool("FlightChic", false);
            }
            else if (PowerUpFeched == "Flight")
            {
                anim.SetBool("FlightChic", true);
            }
        }
        else if (SkinSprite.SelectedSkin == "Real")
        {
            anim.Play("RealClip");
            skin = "real";
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
